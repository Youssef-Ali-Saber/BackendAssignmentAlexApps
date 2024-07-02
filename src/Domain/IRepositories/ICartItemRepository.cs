using Domain.Entities;
using Domain.IRepositories.IGenericRepository;

namespace Domain.IRepositories;

public interface ICartItemRepository : IGenericRepository<CartItem>
{
}
