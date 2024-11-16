using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions.CarSpareDataStore
{
    public interface ISparePartsInfoRepository
    {
        IEnumerable<SparePartsInfo> GetSparePartsInfo();
        void AddSparePartsInfo(SparePartsInfo sparePartsInfo);
        void EditSparePartsInfo(SparePartsInfo sparePartsInfo);
        SparePartsInfo GetSparePartsInfoById(int sparePartsInfoid);
        void DeleteSparePartsInfo(int sparePartsInfoid);

    }
}
