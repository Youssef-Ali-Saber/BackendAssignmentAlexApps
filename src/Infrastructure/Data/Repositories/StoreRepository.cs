﻿using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.GenericRepository;

namespace Infrastructure.Data.Repositories;

public class StoreRepository : GenericRepository<Store> ,IStoreRepository
{
    public StoreRepository(SQLiteDbContext dbContext): base(dbContext){}
}
