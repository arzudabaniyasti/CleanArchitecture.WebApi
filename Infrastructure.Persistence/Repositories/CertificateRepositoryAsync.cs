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
    public class CertificateRepositoryAsync : GenericRepositoryAsync<Certificate>, ICertificateRepositoryAsync
    {
        private readonly DbSet<Certificate> _certificates;

        public CertificateRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _certificates = dbContext.Set<Certificate>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _certificates
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
