using DocumentFormat.OpenXml.Spreadsheet;
using FourGreen.Modals;
using SurveyHub.Admin.Services;
using System.Diagnostics;

namespace FourGreen.DataUser
{
    public class CartService
    {
        readonly CookieService cookieService;
        readonly string cartKey = "cartKey";
        public CartService(CookieService cookieService)
        {
            this.cookieService = cookieService;
        }

        public MyCart myCart = new();
        public List<MyCart> carts = new();
        public async Task<MyCart> PlusCart(CartProduct cart, int userID)
        {
            try
            {
                carts = await cookieService.GetCookie(carts, cartKey);
                var userCart = carts.FirstOrDefault(f => f.userId == userID);
                myCart = userCart ?? new();
                myCart.userId = userID;
                var product = myCart.CartProducts.Where(w => w.Id == cart.Id).FirstOrDefault();
                if (product == null)
                {
                    cart.Qty = +1;
                    myCart.CartProducts.Add(cart);
                }
                else
                {
                    myCart.CartProducts.FirstOrDefault(f => f.Id == product.Id)!.Qty++;
                }
                if (userCart == null)
                    carts.Add(myCart);
                else
                    carts.FirstOrDefault(f => f.userId == userID)!.CartProducts = myCart.CartProducts;
                await cookieService.SetCookie(carts, cartKey, 1440);
                return myCart;
            }
            catch (Exception)
            {
                return new MyCart();
            }
        }
        public async Task Delete(int userId)
        {
            carts = await cookieService.GetCookie(carts, cartKey);
            carts.RemoveAll(r => r.userId == userId);
            if (carts.Count == 0)
                await cookieService.DeleteCookie(cartKey);
            else
                await cookieService.SetCookie(carts, cartKey, 1440);
        }
        public async Task<MyCart> GetMyCartItems(int userid)
        {
            try
            {
                carts = await cookieService.GetCookie(carts, cartKey);
                var userCart = carts.FirstOrDefault(f => f.userId == userid);
                return userCart ?? new();
            }
            catch (Exception)
            {

                return new();
            }
        }

        public async Task<MyCart> MinusToCart(CartProduct cart, int userID)
        {
            try
            {
                carts = await cookieService.GetCookie(carts, cartKey);
                var userCart = carts.FirstOrDefault(f => f.userId == userID);
                myCart = userCart ?? new();
                myCart.userId = userID;
                var product = myCart.CartProducts.Where(w => w.Id == cart.Id).FirstOrDefault();
                if (product?.Qty == 1)
                {
                    myCart.CartProducts.RemoveAll(r => r.Id == product.Id);
                }
                else if (product != null)
                {
                    myCart.CartProducts.FirstOrDefault(f => f.Id == product.Id)!.Qty--;
                }
                if (userCart == null)
                    carts.Add(myCart);
                else
                    carts.FirstOrDefault(f => f.userId == userID)!.CartProducts = myCart.CartProducts;
                await cookieService.SetCookie(carts, cartKey, 1440);
                return myCart;
            }
            catch (Exception)
            {
                return new();
            }
        }

    }
}
