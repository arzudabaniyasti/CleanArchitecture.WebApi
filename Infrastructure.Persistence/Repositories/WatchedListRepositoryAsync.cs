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
    public class WatchedListRepositoryAsync : GenericRepositoryAsync<WatchedList>, IWatchedListRepositoryAsync
    {
        private readonly DbSet<WatchedList> _watchedList;

        public WatchedListRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _watchedList = dbContext.Set<WatchedList>();
        }
    }
}
