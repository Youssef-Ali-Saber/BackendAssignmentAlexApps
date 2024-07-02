using Domain.Entities;
using Domain.IRepositories.IGenericRepository;

namespace Domain.IRepositories;

public interface IProductRepository : IGenericRepository<Product>
{
}
