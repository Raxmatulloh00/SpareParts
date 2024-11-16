using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.BotUsers
{
    public enum BotUserStep:byte
    {
        None = 0,
        Name = 1,
        Phone = 2,
        Active = 100
    }
}
