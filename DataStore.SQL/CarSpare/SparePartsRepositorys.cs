using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;

namespace DataStore.SQL.CarSpare
{
    public class SparePartsRepositorys : ISparePartsRepository
    {
        private readonly FourgreenDbContext fourGreenDbContext;

        public SparePartsRepositorys(FourgreenDbContext _fourGreenDbContext)
        {
            this.fourGreenDbContext = _fourGreenDbContext;
        }

        public void AddSpareParts(SpareParts spareParts)
        {
            fourGreenDbContext.SpareParts.Add(spareParts);
            fourGreenDbContext.SaveChanges();
        }

        public void DeleteSpareParts(int sparePartsid)
        {
            var spare = fourGreenDbContext.SpareParts.Find(sparePartsid);
            if (spare == null) return;

            fourGreenDbContext.SpareParts.Remove(spare);
            fourGreenDbContext.SaveChanges();
        }

        public void EditSpareParts(SpareParts spareParts)
        {
            var spare = fourGreenDbContext.SpareParts.FirstOrDefault(f => f.SparePartsId == spareParts.SparePartsId);
            spare.SparePartsName = spareParts.SparePartsName;
            fourGreenDbContext.SpareParts.Update(spare);
            fourGreenDbContext.SaveChanges();
        }

        public IEnumerable<SpareParts> GetSpareParts()
        {
            return fourGreenDbContext.SpareParts.ToList();
        }

        public SpareParts GetSparePartsById(int sparePartsid)
        {
            return fourGreenDbContext.SpareParts.Find(sparePartsid);
        }
    }
}
