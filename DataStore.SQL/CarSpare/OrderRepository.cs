using DataStore.SQL.Models;
using Info.BotUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.SQL.Models;
using Newtonsoft.Json;
using System.Text.Encodings.Web;

namespace DataStore.SQL.CarSpare
{
    public class OrderRepository
    {
        private readonly FourgreenDbContext fourgreenDbContext;

        public OrderRepository(FourgreenDbContext _fourgreenDbContext)
        {
            this.fourgreenDbContext = _fourgreenDbContext;
        }

        public List<OrderModel> GetOrders(DeliveryStatus status)
        {
            //var sd = fourgreenDbContext.Orders.FirstOrDefault();
            //var dsaa = JsonConvert.DeserializeObject<List<Products>>(sd.Products);
            //Console.WriteLine();

            var neworder = (from s in fourgreenDbContext.Orders
                            join u in fourgreenDbContext.BotUsers on s.UserId equals u.Id
                            where s.Status == status
                            select new OrderModel
                            {
                                Order = new Order
                                {
                                    UserId = s.UserId,
                                    Id = s.Id,
                                    Lat = s.Lat,
                                    Long = s.Long,
                                    StoreNo = s.StoreNo,
                                    DriverName = s.DriverName,
                                    DriverNumber = s.DriverNumber,
                                    CreateDate = s.CreateDate,
                                    CancleDate = s.CancleDate,
                                    FinishDate = s.FinishDate,
                                    OrderNo = s.OrderNo,
                                    Type = s.Type,
                                    ConfirmedTime = s.ConfirmedTime,
                                },
                                Products = JsonConvert.DeserializeObject<List<Products>>(s.Products) ?? new(),
                                BotUser = u
                            }).ToList();
            return neworder;
        }

        public async Task ConfirmOrder(int orderId)
        {
            var order = await this.fourgreenDbContext.Orders.FirstOrDefaultAsync(a => a.Id == orderId);
            if (order != null)
            {
                order.Confirm();
                await this.fourgreenDbContext.SaveChangesAsync();
            }
        }
        public OrderModel Save(OrderModel reuqest)
        {
            Models.OrderModel orderModel = new Models.OrderModel();
            var order = new Info.BotUsers.Order();
            order.NewOrder(reuqest.Order);
            fourgreenDbContext.Orders.Add(order);
            fourgreenDbContext.SaveChanges();
            orderModel.Order = order;
            return orderModel;
        }
    }
}
