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
    public class DiaryRepositoryAsync : GenericRepositoryAsync<Diary>, IDiaryRepositoryAsync
    {
        private readonly DbSet<Diary> _diary;

        public DiaryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _diary = dbContext.Set<Diary>();
        }
    }
}