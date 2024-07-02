using Microsoft.AspNetCore.Identity;
namespace Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public bool IsMerchant { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
    public virtual Cart Cart { get; set; }
}
