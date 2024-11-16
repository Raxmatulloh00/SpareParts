using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.CarSpare
{
    public class SparePartBrands
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<SparePartBrandsImage> sparePartBrandsImages { get; set; }

    }
}
