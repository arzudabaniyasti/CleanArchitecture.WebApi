using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultWatchedLists
    {
        public static async Task<bool> SeedAsync(IWatchedListRepositoryAsync watchedListRepository)
        {

            var watchedList1 = new WatchedList 
            {
                filmId = 1
            };



            var watchedListList = await watchedListRepository.GetAllAsync();
            var _watchedList1 = watchedListList.Where(p => p.filmId.ToString().StartsWith(watchedList1.filmId.ToString())).Count();

            if (_watchedList1 > 0) // ALREADY SEEDED
                return true;


            if (_watchedList1 == 0)
                try
                {
                    await watchedListRepository.AddAsync(watchedList1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }


            return false;

        }
    }
}

