using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions
{

    public class SparePartBrandsActions : ISparePartBrandsActions
    {
        private readonly ISparePartBrandsRepository sparePartBrandsRepository;

        public SparePartBrandsActions(ISparePartBrandsRepository sparePartBrandsRepository)
        {
            this.sparePartBrandsRepository = sparePartBrandsRepository;
        }

        public IEnumerable<SparePartBrands> View()
        {
            return sparePartBrandsRepository.GetSparePartsBrands();
        }

        public int Add(SparePartBrands sparePartBrands)
        {
            sparePartBrandsRepository.AddSparePartsBrands(sparePartBrands);
            return sparePartBrands.Id;
        }

        public void Edit(SparePartBrands sparePartBrands)
        {
            sparePartBrandsRepository.EditSparePartsBrands(sparePartBrands);
        }

        public SparePartBrands GetSparePartBrandsId(int sparePartBrandsid)
        {
            return sparePartBrandsRepository.GetSparePartBrandsById(sparePartBrandsid);
        }

        public void Delete(int sparePartBrandsid)
        {
            sparePartBrandsRepository.DeleteSparePartBrands(sparePartBrandsid);
        }
    }
}
