using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultEvents
    {
        public static async Task<bool> SeedAsync(IEventRepositoryAsync eventRepository, IPersonnelRepositoryAsync personnelRepository, IAddressRepositoryAsync addressRepository)
        {
            var event1 = new Event
            {
                Name = "Tanisma Toplantisi",
                Description = "Kaynasmak icin ayarlanan etkinlik",
                BeginDate = new DateTime(2022, 1, 2),
                EndDate = new DateTime(2022, 1, 7),
                State = "NEW"
            };
            var eventList = await eventRepository.GetAllAsync();
            var _event1 = eventList.Where(p => p.Name.StartsWith(event1.Name)).Count();

            if (_event1 > 0) // ALREADY SEEDED
                return true;



            event1 = await eventRepository.AddAsync(event1);


            Personnel personnel = await personnelRepository.GetByIdAsync(1); // Default personnnel (participant)
            if (personnel == null) // ALREADY SEEDED
                Console.WriteLine("Default participant (personnel) has not found");
            else
            {
                personnel.EventId = event1.Id;
                await personnelRepository.UpdateAsync(personnel);
            }

            Address address = await addressRepository.GetByIdAsync(1); // Default address
            if (address == null) // ALREADY SEEDED
                Console.WriteLine("Default address has not found");
            else
            {
                address.EventId = event1.Id;
                await addressRepository.UpdateAsync(address);
            }


            return false; // NOT ALREADY SEEDED

        }
    }
}
