
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
    public class DefaultAnnouncements
    {
        public static async Task<bool> SeedAsync(IAnnouncementRepositoryAsync announcementRepository)
        {

            var announcement1 = new Announcement
            {
                Title = "Party",
                Type = "Invite",
                StartDate = new DateTime(2021, 01, 20),
                EndDate = new DateTime(2021, 01, 20),
                RequestDate = new DateTime(2021, 01, 20),
                Attachment = "img",
                Company = "akuzem",
                Letter = "we are arranging a birthday party we would like to see you too"
            };



            var announcementList = await announcementRepository.GetAllAsync();
            var _announcement1 = announcementList.Where(p => p.Title.StartsWith(announcement1.Title)).Count();

            if (_announcement1 > 0) // ALREADY SEEDED
                return true;


            if (_announcement1 == 0)
                try
                {
                    await announcementRepository.AddAsync(announcement1);
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
