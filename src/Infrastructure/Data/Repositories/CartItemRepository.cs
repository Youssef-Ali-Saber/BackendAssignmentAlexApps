using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.GenericRepository;

namespace Infrastructure.Data.Repositories;

public class CartItemRepository : GenericRepository<CartItem> , ICartItemRepository
{
    public CartItemRepository(SQLiteDbContext dbContext): base(dbContext) { }
}
