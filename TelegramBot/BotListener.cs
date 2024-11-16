using DataStore.SQL;
using Info.BotUsers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.DataHelpers;

namespace TelegramBot
{
    public class BotListener
    {
        string? BotToken;

        public BotListener(IConfiguration services)
        {
            //Here I setup to read appsettings
            BotToken = services.GetSection("BotToken").Value;
        }
        public void Work()
        {
            var client = new TelegramBotClient(BotToken);
            client.StartReceiving(Update, Error);
        }

        public async Task Update(ITelegramBotClient botclient, Update update, CancellationToken token)
        {   
            var message = update.Message;
            FourgreenDbContext context = FourGreenDbContext();
            var botUser = getBotUser(context, update);
            if (botUser == null) return;

            switch (botUser.UserStep)
            {
                case BotUserStep.None:
                    await sendHello(botclient, update, botUser, context);
                    break;
                case BotUserStep.Name:
                    await nameStep(botclient, update, botUser, context);
                    break;
                case BotUserStep.Phone:
                    await phoneStep(botclient, update, botUser, context);
                    break;
                case BotUserStep.Active:
                    await botclient.SendTextMessageAsync(botUser.TelegramChatId, string.Format(Messages.Info_success), replyMarkup: getMainKeyboard(botUser.Id));
                    break;
            }

            return;
        }


        public static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        private async Task sendHello(ITelegramBotClient botclient, Update update, BotUser botUser, FourgreenDbContext context)
        {
            await botclient.SendTextMessageAsync(botUser.TelegramChatId, string.Format(Messages.Info_start, update.Message?.Chat.FirstName), Telegram.Bot.Types.Enums.ParseMode.Html);
            await botclient.SendTextMessageAsync(botUser.TelegramChatId, Messages.Info_create_name);
            botUser.UserStep = BotUserStep.Name;
            context.SaveChanges();
        }

        private async Task nameStep(ITelegramBotClient botclient, Update update, BotUser botUser, FourgreenDbContext context)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new KeyboardButton(Messages.KYB_Phone) { RequestContact = true });
            replyKeyboardMarkup.ResizeKeyboard = true;
            await botclient.SendTextMessageAsync(botUser.TelegramChatId, Messages.Info_create_phone, replyMarkup: replyKeyboardMarkup);
            botUser.Name = update.Message?.Text;
            botUser.UserStep = BotUserStep.Phone;
            context.SaveChanges();
        }

        private async Task phoneStep(ITelegramBotClient botclient, Update update, BotUser botUser, FourgreenDbContext context)
        {
            if (update.Message?.Contact == null)
            {
                ReplyKeyboardMarkup replyKeyboardMarkup1 = new ReplyKeyboardMarkup(new KeyboardButton(Messages.KYB_Phone) { RequestContact = true });
                replyKeyboardMarkup1.ResizeKeyboard = true;
                await botclient.SendTextMessageAsync(botUser.TelegramChatId, Messages.Info_create_phone, replyMarkup: replyKeyboardMarkup1);
                return;
            }

            await botclient.SendTextMessageAsync(botUser.TelegramChatId, Messages.Info_success, replyMarkup: getMainKeyboard(botUser.Id));
            botUser.PhoneNumber = update.Message?.Contact.PhoneNumber;
            botUser.UserStep = BotUserStep.Active;
            context.SaveChanges();
        }

        private BotUser getBotUser(FourgreenDbContext db, Update update)
        {
            if (update.Message == null) return null;
            var chatId = update.Message.Chat.Id;
            var botUser = db.BotUsers.FirstOrDefault(f => f.TelegramChatId == chatId);
            if (botUser == null)
            {
                botUser = new BotUser
                {
                    CreateDate = DateTime.Now,
                    Name = update.Message.Chat.FirstName,
                    PhoneNumber = "",
                    TelegramChatId = chatId,
                    UserStep = BotUserStep.None
                };
                db.BotUsers.Add(botUser);
                db.SaveChanges();
            }
            return botUser;
        }

        private ReplyKeyboardMarkup getMainKeyboard(int id)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(
                new List<KeyboardButton>{
                    new KeyboardButton(Messages.KYB_About) { WebApp = new WebAppInfo{ Url = "https://5426-84-54-74-103.ngrok-free.app/bot"} },
                    new KeyboardButton(Messages.KYB_Order) { WebApp = new WebAppInfo{ Url =$"https://5426-84-54-74-103.ngrok-free.app/order/{id}"} }
            });
            replyKeyboardMarkup.ResizeKeyboard = true;
            return replyKeyboardMarkup;
        }

        private FourgreenDbContext FourGreenDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FourgreenDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=RAXMATULLOH\\SQLEXPRESS;Initial Catalog=FourGreen;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True"
                );
            return new FourgreenDbContext(optionsBuilder.Options);
        }
    }
}
