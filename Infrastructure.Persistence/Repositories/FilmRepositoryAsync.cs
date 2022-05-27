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
    public class FilmRepositoryAsync : GenericRepositoryAsync<Film>, IFilmmRepositoryAsync
    {
        private readonly DbSet<Film> _film;

        public FilmRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _film = dbContext.Set<Film>();
        }
    }
}
