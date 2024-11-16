using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions
{
    public class SparePartsInfoActions : ISparePartsInfoActions
    {
        private readonly ISparePartsInfoRepository sparePartsInfoRepository;

        public SparePartsInfoActions(ISparePartsInfoRepository _sparePartsInfoRepository)
        {
            this.sparePartsInfoRepository = _sparePartsInfoRepository;
        }

        public IEnumerable<SparePartsInfo> View()
        {
            return sparePartsInfoRepository.GetSparePartsInfo();
        }
        public int Add(SparePartsInfo sparePartsInfo)
        {
            sparePartsInfoRepository.AddSparePartsInfo(sparePartsInfo);
            return sparePartsInfo.SparePartsInfoId;
        }

        public void Edit(SparePartsInfo sparePartsInfo)
        {
            sparePartsInfoRepository.EditSparePartsInfo(sparePartsInfo);
        }

        public SparePartsInfo GetSparePartsInfoId(int sparePartsInfoid)
        {
            return sparePartsInfoRepository.GetSparePartsInfoById(sparePartsInfoid);
        }

        public void Delete(int sparePartsInfoid)
        {
            sparePartsInfoRepository.DeleteSparePartsInfo(sparePartsInfoid);
        }
    }
}
