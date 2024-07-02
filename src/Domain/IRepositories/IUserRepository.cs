using Domain.Entities;
using Domain.IRepositories.IGenericRepository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain.IRepositories;

public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    Task<IdentityResult> CreateUserAsync(ApplicationUser user, string Password);
    Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string type);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string Password);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
    Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
    Task<bool> IsInRoleAsync(ApplicationUser user, string role);
}
