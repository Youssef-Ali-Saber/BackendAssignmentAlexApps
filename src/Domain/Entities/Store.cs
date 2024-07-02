namespace Domain.Entities;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MerchantId { get; set; } 
    public virtual ApplicationUser Merchant { get; set; }
    public bool VATIncluded { get; set; }
    public decimal VATRate { get; set; }
    public decimal ShippingCost { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
