
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkHistoryRepositoryAsync : GenericRepositoryAsync<WorkHistory>, IWorkHistoryRepositoryAsync
    {
        private readonly DbSet<WorkHistory> _workHistories;

        public WorkHistoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _workHistories = dbContext.Set<WorkHistory>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _workHistories
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
