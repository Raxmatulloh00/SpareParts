using Actions.CarSpareDataStore;
using Info.CarSpare;
using Info.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreInMemory.CarSpare
{
    public class SparePartsRepository : ISparePartsRepository
    {
        private List<SpareParts> sparePart;

        public SparePartsRepository()
        {
            sparePart = new List<SpareParts>()
            {
                new SpareParts {SparePartsId = 1, SparePartsName= "Свеча Правада"},
                new SpareParts {SparePartsId = 2, SparePartsName= "Термастат"},
                new SpareParts {SparePartsId = 3, SparePartsName= "Свеча"},
            };
        }

        public void AddSpareParts(SpareParts spareParts)
        {
            if (sparePart.Any(a => a.SparePartsName.Equals(spareParts.SparePartsName, StringComparison.OrdinalIgnoreCase))) return;
            
            if ( sparePart !=null && sparePart.Count>0)
            {
                var maxId= sparePart.Max(a => a.SparePartsId);  
                spareParts.SparePartsId = maxId + 1;
            }
            else
            {
                spareParts.SparePartsId = 1;
            }

            sparePart.Add(spareParts);
        }

        public void DeleteSpareParts(int sparePartsid)
        {
            sparePart.Remove(GetSparePartsById(sparePartsid));
        }

        public void EditSpareParts(SpareParts spareParts)
        {
            var sparePartsToEdit = GetSparePartsById(spareParts.SparePartsId);
            if (sparePartsToEdit != null)
            {
                sparePartsToEdit.SparePartsName = spareParts.SparePartsName;
            }
        }

        public IEnumerable<SpareParts> GetSpareParts()
        {
            return sparePart;
        }

        public SpareParts GetSparePartsById(int sparePartsid)
        {
            return sparePart.FirstOrDefault(f => f.SparePartsId == sparePartsid);
        }
    }
}
