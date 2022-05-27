using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultFilms
    {
        public static async Task<bool> SeedAsync(IFilmmRepositoryAsync filmRepository)
        {

            var film1 = new Film
            {
                filmName = "Party",
                releaseYear = 200,
                genre = "horror",
                filmBrief = "aa",
                filmRating = 4.5,
                duration = 50,
                filmPoster = "akuzem",
                trailer = "we are arranging a birthday party we would like to see you too"
            };



            var filmList = await filmRepository.GetAllAsync();
            var _film1 = filmList.Where(p => p.filmName.StartsWith(film1.filmName)).Count();

            if (_film1 > 0) // ALREADY SEEDED
                return true;


            if (_film1 == 0)
                try
                {
                    await filmRepository.AddAsync(film1);
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
