using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultInventories
    {
        public static async Task<bool> SeedAsync(IInventoryRepositoryAsync inventoryRepository, IProductRepositoryAsync productRepository)
        {
            var inventory1 = new Inventory
            {
                Name = "Akuzem Demirbas",
            };
            var inventoryList = await inventoryRepository.GetAllAsync();
            var _inventory1 = inventoryList.Where(p => p.Name.StartsWith(inventory1.Name)).Count();

            if (_inventory1 > 0) // ALREADY SEEDED
                return true;



            inventory1 = await inventoryRepository.AddAsync(inventory1);


            Product product = await productRepository.GetByIdAsync(1); // Default product
            if (product == null) // ALREADY SEEDED
                Console.WriteLine("Default product has not found");
            else
            {
                product.InventoryId = inventory1.Id;
                await productRepository.UpdateAsync(product);
            }
            

            return false; // NOT ALREADY SEEDED

        }
    }
}
