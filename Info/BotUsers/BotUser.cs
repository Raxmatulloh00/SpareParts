using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Info.BotUsers
{
    public class BotUser
    {
        public int Id { get; set; }
        public long TelegramChatId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public BotUserStep UserStep { get; set; }
        public DateTime? CreateDate { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
