using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultSearches
    {
        public static async Task<bool> SeedAsync(ISearchRepositoryAsync searchRepository)
        {

            var search1 = new Search
            {
                searchContent = "taxi driver"
            };



            var searchList = await searchRepository.GetAllAsync();
            var _search1 = searchList.Where(p => p.searchContent.StartsWith(search1.searchContent)).Count();

            if (_search1 > 0) // ALREADY SEEDED
                return true;


            if (_search1 == 0)
                try
                {
                    await searchRepository.AddAsync(search1);
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