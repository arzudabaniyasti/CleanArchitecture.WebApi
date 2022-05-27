using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IInventoryRepositoryAsync : IGenericRepositoryAsync<Inventory>
    {
        public Task<IReadOnlyList<Inventory>> GetInventoriesWithProductAsync(int pageNumber, int pageSize);
        public Task<Inventory> GetInventoryWithProductAsync(int inventoryId);
    }
}
