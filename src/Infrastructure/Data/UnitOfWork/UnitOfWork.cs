using Domain.Entities;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SQLiteDbContext db;
    public UnitOfWork(SQLiteDbContext db, UserManager<ApplicationUser> userManager)
    {
        this.db = db;
        UserRepository = new UserRepository(db, userManager);
        StoreRepository = new StoreRepository(db);
        ProductRepository = new ProductRepository(db);
        CartRepository = new CartRepository(db);
        CartItemRepository = new CartItemRepository(db);
    }
    public IUserRepository UserRepository { get; private set; }
    public ICartItemRepository CartItemRepository { get; private set; }

    public ICartRepository CartRepository { get; private set; }

    public IProductRepository ProductRepository { get; private set; }

    public IStoreRepository StoreRepository { get; private set; }

    public async Task SaveAsync()
    {
        await db.SaveChangesAsync();
    }
}
