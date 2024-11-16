namespace FourGreen.Modals
{
    public class MyCart
    {
        public int userId { get; set; }
        public List<CartProduct> CartProducts { get; set; } = new();
    }
    public class CartProduct
    {
        public CartProduct(int id,string name,string brname,string ty,string imgUrl,int qty,double prc)
        {
            Id= id;
            Name= name;
            BrandName= brname;  
            Type = ty;
            ImgUrl= imgUrl;
            Qty = qty;
            price = prc;
        }
        public int Id  { get; set; }
        public string Name { get; set; } = "";
        public string BrandName { get; set; } = "";
        public string Type { get; set; } = "";
        public string ImgUrl { get; set; } = "";
        public int Qty { get; set; }
        public double price { get; set; }
        public double totalSum => Qty * price;
    }
}
