using Info.BotUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL.CarSpare
{
    public class BotUserRepository
    {
        private readonly FourgreenDbContext fourgreenDbContext;

        public BotUserRepository(FourgreenDbContext _fourgreenDbContext)
        {
            fourgreenDbContext = _fourgreenDbContext;
        }

        public List<BotUser> GetUsers()
        {
            return fourgreenDbContext.BotUsers.ToList();
        }

        public BotUser GetBotUserOrderId(int id)
        {
            return fourgreenDbContext.BotUsers.Find(id);
        }
    }
}
