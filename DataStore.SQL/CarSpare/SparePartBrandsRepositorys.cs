using Actions.CarSpareActions.CarSpareDataStore;
using Info.CarSpare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL.CarSpare
{
    public class SparePartBrandsRepositorys : ISparePartBrandsRepository
    {
        private readonly FourgreenDbContext fourGreenDbContext;

        public SparePartBrandsRepositorys(FourgreenDbContext fourGreenDbContext)
        {
            this.fourGreenDbContext = fourGreenDbContext;
        }

        public void AddSparePartsBrands(SparePartBrands sparePartBrands)
        {
            fourGreenDbContext.SparePartBrands.Add(sparePartBrands);
            fourGreenDbContext.SaveChanges();
        }

        public void DeleteSparePartBrands(int sparePartBrandsid)
        {
            var spare = fourGreenDbContext.SparePartBrands.Find(sparePartBrandsid);
            if (spare == null) return;

            fourGreenDbContext.SparePartBrands.Remove(spare);
            fourGreenDbContext.SaveChanges();
        }

        public void EditSparePartsBrands(SparePartBrands sparePartBrands)
        {
            var spare = fourGreenDbContext.SparePartBrands.FirstOrDefault(f=> f.Id == sparePartBrands.Id);
            spare.Name = sparePartBrands.Name;
            fourGreenDbContext.SparePartBrands.Update(spare);
            fourGreenDbContext.SaveChanges();
        }

        public SparePartBrands GetSparePartBrandsById(int sparePartBrandsid)
        {
            var brand = fourGreenDbContext.SparePartBrands.Where(f=>f.Id==sparePartBrandsid).Include(f=>f.sparePartBrandsImages).FirstOrDefault();
            return brand ?? new();
        }

        public IEnumerable<SparePartBrands> GetSparePartsBrands()
        {
            return fourGreenDbContext.SparePartBrands.ToList();
        }
    }
}
