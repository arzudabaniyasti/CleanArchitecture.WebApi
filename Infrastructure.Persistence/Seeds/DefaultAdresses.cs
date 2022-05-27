
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
    public class DefaultAddresses
    {
        public static async Task<bool> SeedAsync(IAddressRepositoryAsync addressRepository)
        {

            var address1 = new Address
            {
                Name = "Akuzem",
                Street = "Su urunleri fakultesi, Akuzem.",
                City = "Antalya",
                Town = "Pinarbasi mah."
            };

            var addressList = await addressRepository.GetAllAsync();
            var _address1 = addressList.Where(p => p.Name.StartsWith(address1.Name)).Count();

            if (_address1 > 0) // ALREADY SEEDED
                return true;


            if (_address1 == 0)
                try
                {
                    await addressRepository.AddAsync(address1);
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
