
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;
//using Interfaces.Repositories;
//using EScooterON.WebApi.Domain.Entities;
//using EScooterON.WebApi.Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultCategories
    {
        public static async Task<bool> SeedAsync(ICategoryRepositoryAsync categoryRepository)
        {

            var category1 = new Category
            {
                Name = "Categori 1",
                Description = "Categori 1 Açıklaması"
            };

            var categoryList = await categoryRepository.GetAllAsync();
            var _category1 = categoryList.Where(p => p.Name.StartsWith(category1.Name)).Count();

            if (_category1 > 0) // ALREADY SEEDED
                return true;


            if (_category1 == 0)
                try
                {
                    await categoryRepository.AddAsync(category1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            //var _scooter2 = scooterList.Where(p => p.ScooterBarcode.StartsWith(scooter2.ScooterBarcode)).Count();
            //if (_scooter2 == 0)
            //    await scooterRepository.AddAsync(scooter2);

            ////var _scooter3 = scooterList.Where(p => p.ScooterName.StartsWith(scooter3.ScooterName)).Count();
            //// if (_scooter3 == 0)
            ////    await scooterRepository.AddAsync(scooter3);


            return false; // NOT ALREADY SEEDED

        }
    }
}
