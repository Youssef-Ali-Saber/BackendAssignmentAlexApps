using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.GenericRepository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Data.Repositories;

public class UserRepository(SQLiteDbContext dbContext, UserManager<ApplicationUser> userManager) : GenericRepository<ApplicationUser>(dbContext), IUserRepository
{

    public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string type)
    {
        return await userManager.AddToRoleAsync(user, type);
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string Password)
    {
        return await userManager.CheckPasswordAsync(user, Password);
    }

    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string Password)
    {
        return await userManager.CreateAsync(user, Password);
    }


    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
    {
        return await userManager.GetClaimsAsync(user);
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
    {
        return await userManager.GetRolesAsync(user);
    }

    public async Task<bool> IsInRoleAsync(ApplicationUser user, string role)
    {
        return await userManager.IsInRoleAsync(user, role);
    }

}
