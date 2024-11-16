using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;
namespace DataStore.SQL.CarSpare
{
    public class SparePartsInfoRepositorys : ISparePartsInfoRepository
    {
        private readonly FourgreenDbContext fourGreenDbContext;

        public SparePartsInfoRepositorys(FourgreenDbContext _fourGreenDbContext)
        {
            this.fourGreenDbContext = _fourGreenDbContext;
        }

        public void AddSparePartsInfo(SparePartsInfo sparePartsInfo)
        {


            fourGreenDbContext.SparePartsInfos.Add(sparePartsInfo);
            fourGreenDbContext.SaveChanges();


        }

        public void DeleteSparePartsInfo(int sparePartsInfoid)
        {
            var sapareinfo = fourGreenDbContext.SparePartsInfos.Find(sparePartsInfoid);
            if (sapareinfo == null) return;

            fourGreenDbContext.SparePartsInfos.Remove(sapareinfo);
            fourGreenDbContext.SaveChanges();
        }

        public void EditSparePartsInfo(SparePartsInfo sparePartsInfo)
        {
            var spareinfo = fourGreenDbContext.SparePartsInfos.FirstOrDefault(f => f.SparePartsInfoId == sparePartsInfo.SparePartsInfoId);
            spareinfo.SparePartBrandsConnectedId = sparePartsInfo.SparePartBrandsConnectedId;
            spareinfo.SparePartsConnectedId = sparePartsInfo.SparePartsConnectedId;
            spareinfo.SparePartsInfoName = sparePartsInfo.SparePartsInfoName;
            spareinfo.Quntity = sparePartsInfo.Quntity;
            spareinfo.Price = sparePartsInfo.Price;
            spareinfo.CatologNumber = sparePartsInfo.CatologNumber;
            fourGreenDbContext.SparePartsInfos.Update(spareinfo);
            fourGreenDbContext.SaveChanges();
        }

        public IEnumerable<SparePartsInfo> GetSparePartsInfo()
        {
            return fourGreenDbContext.SparePartsInfos.ToList();
        }

        public SparePartsInfo GetSparePartsInfoById(int sparePartsInfoid)
        {
            return fourGreenDbContext.SparePartsInfos.Find(sparePartsInfoid);
        }
    }
}
