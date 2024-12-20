﻿using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.GenericRepository;

namespace Infrastructure.Data.Repositories;

public class ProductRepository : GenericRepository<Product> , IProductRepository
{
    public ProductRepository(SQLiteDbContext dbContext): base(dbContext) { }
}
