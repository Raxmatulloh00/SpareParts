using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.CarSpare
{
    public class SparePartsInfo
    {
        [Required]
        [ForeignKey("SparePartBrands")]
        public int SparePartBrandsConnectedId { get; set; }
        [Required]
        [ForeignKey("SpareParts")]
        public int SparePartsConnectedId { get; set; }
        public int SparePartsInfoId { get; set; }
        [Required]
        public string CatologNumber { get; set; }
        [Required]
        public string SparePartsInfoName { get; set; }
        [Required]
        public int Quntity { get; set; }
        [Required]
        public double Price { get; set; }
        public SpareParts SpareParts { get; set; }
        public SparePartBrands SparePartBrands { get; set; }
        public ICollection<SparePartsInfoImage> sparePartsInfoImages { get; set; }
    }
}
