using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Info.BotUsers
{
    public class Order
    {
        [ForeignKey("BotUser")]
        public int UserId { get; set; }
        public int Id { get; set; }
        public decimal OrderNo { get; set; }
        public DeliveryStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CancleDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Products { get; set; } = string.Empty;
        public OrderType Type { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string DriverNumber { get; set; } = string.Empty;
        public string StoreNo { get; set; } = string.Empty;
        public DateTime? ConfirmedTime { get; set; }
        public void NewOrder(Order order)
        {
            UserId = order.UserId;
            Status = DeliveryStatus.New;
            CreateDate = DateTime.Now;
            Products = order.Products;
            Type = order.Type;
            Lat = order.Lat;
            Long = order.Long;
            DriverName = order.DriverName;
            DriverNumber = order.DriverNumber;
            StoreNo = order.StoreNo;
        }
        public void Confirm()
        {
            ConfirmedTime= DateTime.Now;
            Status = DeliveryStatus.Confirmed;
        }
    }

    public enum DeliveryStatus
    {
        New = 0,
        Confirmed = 10,
        Shipping = 20,
        Delivered = 200,
        Cancel = 500
    }
    public enum OrderType
    {
        Takeout = 0,
        Delivery = 10,
        RegionDelivery = 20,
    }

    public class Products
    {
        public int productId { get; set; }
        public string productBrand { get; set; }
        public string productTaype { get; set; }
        public string productName { get; set; }
        public int qty { get; set; }
        public double price { get; set; }
        public string CatalogNumber { get; set; }
    }

}
