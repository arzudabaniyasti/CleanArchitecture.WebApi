
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
    public class DefaultWorkHistories
    {
        public static async Task<bool> SeedAsync(IWorkHistoryRepositoryAsync workHistoryRepository)
        {

            var defaultWorkHistory = new WorkHistory
            {
                Position = "Manager",
                CompanyName = "Akuzem"
            };



            var workHistoryList = await workHistoryRepository.GetAllAsync();
            var _defaultWorkHistory = workHistoryList.Where(p => p.CompanyName.StartsWith(defaultWorkHistory.CompanyName)).Count();

            if (_defaultWorkHistory > 0) // ALREADY SEEDED
                return true;


            if (_defaultWorkHistory == 0)
                try
                {
                    await workHistoryRepository.AddAsync(defaultWorkHistory);
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
