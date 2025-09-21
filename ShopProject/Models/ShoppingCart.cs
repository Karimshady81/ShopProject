
using Microsoft.EntityFrameworkCore;

namespace ShopProject.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ShopProjectDbContext _shopProjectDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(ShopProjectDbContext shopProjectDbContext)
        {
            _shopProjectDbContext = shopProjectDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ShopProjectDbContext context = services.GetService<ShopProjectDbContext>() ?? throw new Exception("Error Initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                _shopProjectDbContext.ShoppingCartItems.SingleOrDefault(s => s.ShoppingCartId == ShoppingCartId && s.Pie.PieId == pie.PieId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _shopProjectDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _shopProjectDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var ShoppingCartItem = 
                _shopProjectDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if(ShoppingCartItem != null)
            {
                if(ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    _shopProjectDbContext.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }

            _shopProjectDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                        _shopProjectDbContext.ShoppingCartItems
                        .Where(c => c.ShoppingCartId == ShoppingCartId)
                        .Include(s => s.Pie)
                        .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _shopProjectDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _shopProjectDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _shopProjectDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _shopProjectDbContext.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Select(c => c.Pie.Price * c.Amount).Sum();

            return total;
        }
    }
}
