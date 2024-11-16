using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Info.CarSpare;
namespace DataStore.SQL.CarSpare
{
    public class ImageRepositorys
    {
        private readonly FourgreenDbContext fourGreenDbContext;

        public ImageRepositorys(FourgreenDbContext _fourGreenDbContext)
        {
            fourGreenDbContext = _fourGreenDbContext;
        }

        public void AddImage(SparePartsInfoImage image)
        {
            fourGreenDbContext.SparePartsInfoImages.Add(image);
            fourGreenDbContext.SaveChanges();
        }

        public void DeleteImage (int  imageid)
        {
            var image = fourGreenDbContext.SparePartsInfoImages.FirstOrDefault(x => x.Id == imageid);
            fourGreenDbContext.SparePartsInfoImages.Remove(image);
            fourGreenDbContext.SaveChanges();
        }

        public IEnumerable<SparePartsInfoImage> Get()
        {
            return fourGreenDbContext.SparePartsInfoImages.ToList();
        }

        public List<SparePartsInfoImage> GetBySparePartsId(int sparepartsId)
        {
            var images = from x in fourGreenDbContext.SparePartsInfoImages
                        where x.SparePartsInfoConnectId == sparepartsId
                        select x; 
            return images.ToList();
        }
    }
}
