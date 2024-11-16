using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions.CarSpareDataStore
{
    public interface ISparePartBrandsRepository
    {
        IEnumerable<SparePartBrands> GetSparePartsBrands();
        void AddSparePartsBrands(SparePartBrands sparePartBrands);
        void EditSparePartsBrands(SparePartBrands sparePartBrands);
        SparePartBrands GetSparePartBrandsById(int sparePartBrandsid);
        void DeleteSparePartBrands(int sparePartBrandsid);
    }
}
