
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
    public class DefaultContacts
    {
        public static async Task<bool> SeedAsync(IContactRepositoryAsync contactRepository)
        {

            var contact1 = new Contact
            {
                Name = "BTK Akademi",
                Email = "Email",
               Address="Address"
               
            };

            var contactList = await contactRepository.GetAllAsync();
            var _contact1 = contactList.Where(p => p.Name.StartsWith(contact1.Name)).Count();

            if (_contact1 > 0) // ALREADY SEEDED
                return true;


            if (_contact1 == 0)
                try
                {
                    await contactRepository.AddAsync(contact1);
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
