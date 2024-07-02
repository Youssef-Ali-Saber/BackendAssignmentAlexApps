using static System.Formats.Asn1.AsnWriter;

namespace Domain.Entities;


public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; } 
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            List<Store> stores = new ();
            foreach (var item in CartItems)
            {
                var product = item.Product; 
                decimal itemTotal = product.Price * item.Quantity;
                totalPrice += itemTotal;
                stores.Add(item.Product.Store);
                var store = item.Product.Store;
                if (!store.VATIncluded)
                {
                    totalPrice += store.VATRate * product.Price;
                }
            }
            var distinctStores = stores.Distinct();
            foreach (var store in distinctStores)
            {
                totalPrice += store.ShippingCost;
            }
            return totalPrice;
        }
    }
}
