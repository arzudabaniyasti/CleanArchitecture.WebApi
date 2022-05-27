
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
    public class DefaultCertificates
    {
        public static async Task<bool> SeedAsync(ICertificateRepositoryAsync certificateRepository)
        {

            var certificate1 = new Certificate
            {
                Name = "BTK Akademi",
                Provider = "Devlet",
                StartDate = new DateTime(2021, 01, 20),
                EndDate = new DateTime(2023, 06, 10),
            };

            var certificateList = await certificateRepository.GetAllAsync();
            var _certificate1 = certificateList.Where(p => p.Name.StartsWith(certificate1.Name)).Count();

            if (_certificate1 > 0) // ALREADY SEEDED
                return true;


            if (_certificate1 == 0)
                try
                {
                    await certificateRepository.AddAsync(certificate1);
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
