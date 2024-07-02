using Domain.IRepositories;

namespace Domain.IUnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IStoreRepository StoreRepository { get; }
    IProductRepository ProductRepository{ get; }
    ICartRepository CartRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    Task SaveAsync();

}
