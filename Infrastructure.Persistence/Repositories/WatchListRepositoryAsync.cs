using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class WatchListRepositoryAsync : GenericRepositoryAsync<WatchList>, IWatchListRepositoryAsync
    {
        private readonly DbSet<WatchList> _watchList;

        public WatchListRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _watchList = dbContext.Set<WatchList>();
        }
    }
}
