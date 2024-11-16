using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL.Models
{
    public class SparePartsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Brandid {  get; set; }
    }
}
