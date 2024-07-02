using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.GenericRepository;

namespace Infrastructure.Data.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(SQLiteDbContext dbContext): base(dbContext) { }
}
