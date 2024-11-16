using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions.CarSpareActions.CarSpareDataStore
{
    public interface ISparePartsRepository
    {
        IEnumerable<SpareParts> GetSpareParts();
        void AddSpareParts(SpareParts spareParts);
        void EditSpareParts(SpareParts spareParts);
        SpareParts GetSparePartsById(int sparePartsid);
        void DeleteSpareParts(int sparePartsid);
    }
}
