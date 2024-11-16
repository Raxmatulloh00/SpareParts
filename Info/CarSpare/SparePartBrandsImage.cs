using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.CarSpare
{
    public class SparePartBrandsImage
    {
        public int Id { get; set; }
        public string ImageURl { get; set; }
        [ForeignKey("SparePartBrands")]
        public int SparePartBrandId { get; set; }
        public SparePartBrands SparePartBrands { get; set; }
        public string ImageName { get; set; }
    }
}
