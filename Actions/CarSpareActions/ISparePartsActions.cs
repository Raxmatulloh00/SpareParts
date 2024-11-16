using Info.CarSpare;

namespace Actions.CarSpareActions
{
    public interface ISparePartsActions
    {
        void Add(SpareParts spareParts);
        void Delete(int sparePartsid);
        void Edit(SpareParts spareParts);
        SpareParts GetSparePartsId(int sparePartsid);
        IEnumerable<SpareParts> View();
    }
}