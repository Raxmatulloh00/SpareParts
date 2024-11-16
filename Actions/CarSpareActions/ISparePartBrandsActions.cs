using Info.CarSpare;

namespace Actions.CarSpareActions
{
    public interface ISparePartBrandsActions
    {
        int Add(SparePartBrands sparePartBrands);
        void Delete(int sparePartBrandsid);
        void Edit(SparePartBrands sparePartBrands);
        SparePartBrands GetSparePartBrandsId(int sparePartBrandsid);
        IEnumerable<SparePartBrands> View();
    }
}