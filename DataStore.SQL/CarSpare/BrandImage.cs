using Info.CarSpare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStore.SQL.CarSpare
{
    public class BrandImage
    {
        private readonly FourgreenDbContext fourGreenDbContext;

        public BrandImage(FourgreenDbContext _fourgreenDbContext)
        {
            fourGreenDbContext = _fourgreenDbContext;
        }

        public void AddImage (SparePartBrandsImage image)
        {
            fourGreenDbContext.SparePartBrandsImages.Add(image);
            fourGreenDbContext.SaveChanges();
        }

        public void DeleteImage (int imageid)
        {
            var image = fourGreenDbContext.SparePartBrandsImages.FirstOrDefault(x => x.Id == imageid);
            fourGreenDbContext.SparePartBrandsImages.Remove(image);
            fourGreenDbContext.SaveChanges();
        }

        public IEnumerable<SparePartBrandsImage> Get()
        {
            return fourGreenDbContext.SparePartBrandsImages.ToList();
        }

        public List<SparePartBrandsImage> GetBySparePartBrandsId(int sparepartbrandsid)
        {
            var image = from x in fourGreenDbContext.SparePartBrandsImages
                        where x.SparePartBrandId == sparepartbrandsid
                        select x;
            return image.ToList();
        }
    }
}
