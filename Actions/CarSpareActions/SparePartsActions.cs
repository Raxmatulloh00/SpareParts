using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions
{
    public class SparePartsActions : ISparePartsActions
    {
        private readonly ISparePartsRepository sparePartsRepository;

        public SparePartsActions(ISparePartsRepository _sparePartsRepository)
        {
            this.sparePartsRepository = _sparePartsRepository;
        }

        public IEnumerable<SpareParts> View()
        {
            return sparePartsRepository.GetSpareParts();
        }
        public void Add(SpareParts spareParts)
        {
            sparePartsRepository.AddSpareParts(spareParts);
        }

        public void Edit(SpareParts spareParts)
        {
            sparePartsRepository.EditSpareParts(spareParts);
        }

        public SpareParts GetSparePartsId(int sparePartsid)
        {
            return sparePartsRepository.GetSparePartsById(sparePartsid);
        }

        public void Delete(int sparePartsid)
        {
            sparePartsRepository.DeleteSpareParts(sparePartsid);
        }
    }
}
