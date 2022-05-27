using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class InventoryRepositoryAsync : GenericRepositoryAsync<Inventory>, IInventoryRepositoryAsync
    {
        private readonly DbSet<Inventory> _inventories;

        public InventoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _inventories = dbContext.Set<Inventory>();
        }


        public async Task<IReadOnlyList<Inventory>> GetInventoriesWithProductAsync(int pageNumber, int pageSize)
        {
            return await _inventories.Include(x => x.Products).OrderBy(x=>x.Id).
                Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

        }

        public async Task<Inventory> GetInventoryWithProductAsync(int inventoryId)
        {
            return await _inventories.Include(p => p.Products).SingleOrDefaultAsync(x => x.Id == inventoryId);
        }

    }
}
