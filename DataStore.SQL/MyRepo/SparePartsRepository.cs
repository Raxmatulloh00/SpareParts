using DataStore.SQL;
using DataStore.SQL.Models;
using Info.CarSpare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataStore.SQL.MyRepo
{
    public class SparePartsRepository
    {

        private readonly FourgreenDbContext _dbContext;
        public SparePartsRepository(FourgreenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BrandModel> GetBrands()
        {
            var myq = (from brand in _dbContext.SparePartBrands
                       from imgs in _dbContext.SparePartBrandsImages
                       where brand.Id == imgs.SparePartBrandId
                       select new BrandModel
                       {
                           Id = brand.Id,
                           ImgUrl = imgs.ImageURl,
                           Name = brand.Name,
                       }).ToList();
            return myq;
        }


        //public List<BrandImageModel> GetBrandImage()
        //{
        //    var query = from x in _dbContext.SparePartBrandsImages
        //                select new BrandImageModel
        //                {
        //                    Id = x.Id,
        //                    ImageUrl = x.ImageURl,
        //                    BrandId = x.SparePartBrandId,
        //                };
        //    return query.ToList();
        //}
        public List<SparePartsModel> GetCategorys()
        {
            var query = from x in _dbContext.SpareParts
                        join y in _dbContext.SparePartBrands on x.SparePartsId equals y.Id
                        select new SparePartsModel
                        {
                            Id = x.SparePartsId,
                            Name = x.SparePartsName,
                            Brandid = y.Id
                        };
            return query.ToList();
        }





        //public List<SparePartsModel> GetTypes(int id)
        //{

        //    //var res = _dbContext.SpareParts.Where(w => w.SparePartBrandsConnectionId == id).ToList();
        //    var query = from x in _dbContext.SpareParts where x.SparePartBrandsConnectionId == id
        //                select new SparePartsModel
        //                {
        //                    Id = x.SparePartsId,
        //                    Name = x.SparePartsName,
        //                    BrandId = x.SparePartBrandsConnectionId
        //                };
        //    return query.ToList();
        //}

        public bool UpdateQty(SparePartsInfoModel sparePartsInfoModel)
        {
            try
            {
                var partInfo = _dbContext.SparePartsInfos.FirstOrDefault(f => f.SparePartsInfoId == sparePartsInfoModel.Id);
                if (partInfo != null)
                    partInfo.Quntity = sparePartsInfoModel.Quantity;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<SparePartsInfoModel> GetProductsByIds(List<int> productId)
        {
            return _dbContext.SparePartsInfos.Where(w => productId.Contains(w.SparePartsInfoId)).
                Select(s => new SparePartsInfoModel()
                {
                    Id = s.SparePartsInfoId,
                    Quantity = s.Quntity,
                }).ToList();
        }

        public List<SparePartsInfoModel> GetProducts()
        {
            var query = (from x in _dbContext.SparePartsInfos
                         join y in _dbContext.SparePartBrands on x.SparePartBrandsConnectedId equals y.Id
                         join z in _dbContext.SparePartsInfoImages on x.SparePartsInfoId equals z.SparePartsInfoConnectId into cs
                         from z in cs.DefaultIfEmpty()
                         select new SparePartsInfoModel()
                         {
                             Id = x.SparePartsInfoId,
                             Name = x.SparePartsInfoName,
                             Price = x.Price,
                             Quantity = x.Quntity,
                             BrandId = y.Id,
                             BrandName = y.Name,
                             TypeId = x.SpareParts.SparePartsId,
                             TypeName = x.SpareParts.SparePartsName,
                             ImageUrl = z != null ? z.ImageURl : "",
                             CatalogNumber = x.CatologNumber,
                         });
            return query.ToList();
        }

        public List<ImageModel> GetImages()
        {
            var query = from x in _dbContext.SparePartsInfoImages
                        select new ImageModel
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageURl,
                            SparePartsInfoId = x.SparePartsInfoConnectId,
                        };
            return query.ToList();
        }
    }
}
