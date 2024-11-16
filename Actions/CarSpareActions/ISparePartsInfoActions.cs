using Info.CarSpare;

namespace Actions.CarSpareActions
{
    public interface ISparePartsInfoActions
    {
        int Add(SparePartsInfo sparePartsInfo);
        void Delete(int sparePartsInfoid);
        void Edit(SparePartsInfo sparePartsInfo);
        SparePartsInfo GetSparePartsInfoId(int sparePartsInfoid);
        IEnumerable<SparePartsInfo> View();
    }
}