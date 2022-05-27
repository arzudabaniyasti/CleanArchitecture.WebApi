using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonnelRepositoryAsync : GenericRepositoryAsync<Personnel>, IPersonnelRepositoryAsync
    {
        private readonly DbSet<Personnel> _personnels;

        public PersonnelRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _personnels = dbContext.Set<Personnel>();
        }

        public async Task<IReadOnlyList<Personnel>> GetPersonnelsWithRelationsAsync(int pageNumber, int pageSize)
        {
            return await _personnels.Include(x => x.Educations)
                .Include(x => x.Addresses)
                .Include(x => x.Certificates)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

        }

        public async Task<Personnel> GetPersonnelByIdWithRelationsAsync(int personnelId)
        {
            return await _personnels.Include(p => p.Educations)
                .Include(p => p.Addresses).Include(p => p.Certificates).SingleOrDefaultAsync(x => x.Id == personnelId);
        }
    }
}
