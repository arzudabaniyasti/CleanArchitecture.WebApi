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
    public class SearchRepositoryAsync : GenericRepositoryAsync<Search>, ISearchRepositoryAsync
    {
        private readonly DbSet<Search> _search;

        public SearchRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _search = dbContext.Set<Search>();
        }
    }
}
