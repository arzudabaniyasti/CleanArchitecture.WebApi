
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
    public class DefaultProjects
    {
        public static async Task<bool> SeedAsync(IProjectRepositoryAsync projectRepository)
        {

            var project1 = new Project
            {
                Name = "Default Project",
                Description = "Description"
            };

            var projectList = await projectRepository.GetAllAsync();
            var _project1 = projectList.Where(p => p.Name.StartsWith(project1.Name)).Count();

            if (_project1 > 0) // ALREADY SEEDED
                return true;

            if (_project1 == 0)
                try
                {
                    await projectRepository.AddAsync(project1);
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
