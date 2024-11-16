using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.CarSpare
{
    public class SpareParts
    {
        public int SparePartsId { get; set; }
        [Required]
        public string SparePartsName { get; set; }
    }
}
