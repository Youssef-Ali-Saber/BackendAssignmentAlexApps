namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescriptionAr { get; set; }
    public string DescriptionEn { get; set; }
    public decimal Price { get; set; }
    public int StoreId { get; set; }
    public virtual Store Store { get; set; }
}
