
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
    public class DefaultEducations
    {
        public static async Task<bool> SeedAsync(IEducationRepositoryAsync educationRepository)
        {

            var education1 = new Education
            {
                CollegeName = "BTK Akademi",
                Major = "Major",
                StartDate = new DateTime(2021, 01, 20),
                EndDate = new DateTime(2023, 06, 10),
            };

            var educationList = await educationRepository.GetAllAsync();
            var _education1 = educationList.Where(p => p.CollegeName.StartsWith(education1.CollegeName)).Count();

            if (_education1 > 0) // ALREADY SEEDED
                return true;


            if (_education1 == 0)
                try
                {
                    await educationRepository.AddAsync(education1);
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
