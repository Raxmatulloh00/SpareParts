using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.CarSpare
{
    public  class SparePartsInfoImage
    {
        public  int  Id { get; set; }
        public string ImageURl { get; set; }

        [ForeignKey("SparePartsInfo")]
        public int SparePartsInfoConnectId { get; set; }
        public SparePartsInfo SparePartsInfo { get; set; }
        public string ImageName { get; set; }
    }
}
