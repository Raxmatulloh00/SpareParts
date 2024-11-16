using Info.BotUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public List<Products> Products { get; set; } = new();
        public BotUser BotUser { get; set; }
    }

}
