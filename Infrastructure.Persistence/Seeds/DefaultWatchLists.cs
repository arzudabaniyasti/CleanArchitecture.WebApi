using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultWatchLists
    {
        public static async Task<bool> SeedAsync(IWatchListRepositoryAsync watchListRepository)
        {

            var watchList1 = new WatchList
            {
                filmId = 1
            };



            var watchListList = await watchListRepository.GetAllAsync();
            var _watchList1 = watchListList.Where(p => p.filmId.ToString().StartsWith(watchList1.filmId.ToString())).Count();

            if (_watchList1 > 0) // ALREADY SEEDED
                return true;


            if (_watchList1 == 0)
                try
                {
                    await watchListRepository.AddAsync(watchList1);
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