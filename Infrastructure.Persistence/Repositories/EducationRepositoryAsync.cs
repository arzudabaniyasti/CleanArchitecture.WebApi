using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EducationRepositoryAsync : GenericRepositoryAsync<Education>, IEducationRepositoryAsync
    {
        private readonly DbSet<Education> _educations;

        public EducationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _educations = dbContext.Set<Education>();
        }

       /* public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _educations
                .AllAsync(p => p.Barcode != barcode);
        }*/
    }
}
