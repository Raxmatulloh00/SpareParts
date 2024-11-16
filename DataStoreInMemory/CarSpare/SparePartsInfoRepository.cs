using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreInMemory.CarSpare
{
    public class SparePartsInfoRepository : ISparePartsInfoRepository
    {
        private List<SparePartsInfo> sparePartsInfos;

        public SparePartsInfoRepository()
        {
            sparePartsInfos = new List<SparePartsInfo>()
            {
                new SparePartsInfo {SparePartsInfoId = 1, SparePartsConnectedId = 1,CatologNumber="625455DJ58", SparePartsInfoName="Дамас", Price = 4.80, Quntity= 500},
                new SparePartsInfo {SparePartsInfoId = 2, SparePartsConnectedId = 1,CatologNumber="WK8533769D", SparePartsInfoName="Матиз", Price = 4.80, Quntity = 400},
                new SparePartsInfo {SparePartsInfoId = 3, SparePartsConnectedId = 2,CatologNumber="362947AJ5W", SparePartsInfoName="Матиз", Price = 2.70, Quntity = 100},
                new SparePartsInfo {SparePartsInfoId = 4, SparePartsConnectedId = 2,CatologNumber="FE551445D5", SparePartsInfoName="Нексия", Price = 2.70, Quntity = 800},
                new SparePartsInfo {SparePartsInfoId = 5, SparePartsConnectedId = 3,CatologNumber="FD3048NDJ2", SparePartsInfoName="Донс", Price = 6.30, Quntity = 800},
                new SparePartsInfo {SparePartsInfoId = 6, SparePartsConnectedId = 3,CatologNumber="37HB9YWG55", SparePartsInfoName="Сонс", Price = 6.30, Quntity = 800},
            };
        }

        public void AddSparePartsInfo(SparePartsInfo sparePartsInfo)
        {
            if (sparePartsInfos.Any(a => a.SparePartsInfoName.Equals
                        (sparePartsInfo.SparePartsInfoName, StringComparison.OrdinalIgnoreCase))) return;

            if (sparePartsInfos != null && sparePartsInfos.Count > 0)
            {
                var maxId = sparePartsInfos.Max(a => a.SparePartsInfoId);
                sparePartsInfo.SparePartsInfoId = maxId + 1;
            }
            else
            {
                sparePartsInfo.SparePartsInfoId = 1;
            }

            sparePartsInfos.Add(sparePartsInfo);
        }

        public void DeleteSparePartsInfo(int sparePartsInfoid)
        {
            sparePartsInfos.Remove(GetSparePartsInfoById(sparePartsInfoid));
        }

        public void EditSparePartsInfo(SparePartsInfo sparePartsInfo)
        {
            var sparePartsInfoToEdit =  GetSparePartsInfoById(sparePartsInfo.SparePartsInfoId);
            if (sparePartsInfoToEdit != null)
            {
                sparePartsInfoToEdit.SparePartsConnectedId = sparePartsInfo.SparePartsConnectedId;
                sparePartsInfoToEdit.CatologNumber = sparePartsInfo.CatologNumber;
                sparePartsInfoToEdit.SparePartsInfoName = sparePartsInfo.SparePartsInfoName;
                sparePartsInfoToEdit.Price = sparePartsInfo.Price;
                sparePartsInfoToEdit.Quntity = sparePartsInfo.Quntity;
            }
        }

        public IEnumerable<SparePartsInfo> GetSparePartsInfo()
        {
            return sparePartsInfos;
        }

        public SparePartsInfo GetSparePartsInfoById(int sparePartsInfoid)
        {
            return sparePartsInfos.FirstOrDefault(f => f.SparePartsInfoId == sparePartsInfoid);
        }

    }
}
