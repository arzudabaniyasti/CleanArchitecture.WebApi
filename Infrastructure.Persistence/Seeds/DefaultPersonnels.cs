using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultPersonnels
    {
        public static async Task<bool> SeedAsync(IPersonnelRepositoryAsync personnelRepository)
        {
            var education = new Education
            {
                CollegeName = "BTK Akademi",
                Major = "Major",
                StartDate = new DateTime(2021, 01, 20),
                EndDate = new DateTime(2023, 06, 10)
            };
            
            var address = new Address
            {
                Name = "Su uruleri",
                Street = "Cadde",
                City = "Antalya",
                Town = "Pinarbasi mah."
            };

            var certificate = new Certificate
            {
                Name = "BTK Akademi",
                Provider = "Devlet",
                StartDate = new DateTime(2021, 01, 20),
                EndDate = new DateTime(2023, 06, 10)
            };
            List<Education> educations = new List<Education>
            {
                education
            };
            List<Address> addresses = new List<Address>
            {
                address
            };
            List<Certificate> certificates = new List<Certificate>
            {
                certificate
            };

            var personnel1 = new Personnel
            {
                FirstName = "Mehmet",
                LastName = "Karagöz",
                Email = "abcd@gmail.com",
                Description = "acıklama",
                PhoneNumber = "05554443322",
                BirthDate = new DateTime(2000, 10, 21),
                Gender = "Male",
                Avatar = "NNNN",
                Educations = educations,
                Addresses = addresses,
                Certificates = certificates
            };

            var personnelList = await personnelRepository.GetAllAsync();
            var _personnel1 = personnelList.Where(p => p.FirstName.StartsWith(personnel1.FirstName)).Count();

            if (_personnel1 > 0) // ALREADY SEEDED
                return true;


            if (_personnel1 == 0)
                try
                {
                    await personnelRepository.AddAsync(personnel1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            return false; // NOT ALREADY SEEDED

        }
    }
}
