using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultDiaries
    {
        public static async Task<bool> SeedAsync(IDiaryRepositoryAsync diaryRepository)
        {

            var diary1 = new Diary
            {
                filmId = 1,
                addingDate = new DateTime(2017,8,24),
                userRating = 4.5
            };



            var diaryList = await diaryRepository.GetAllAsync();
            var _diary1 = diaryList.Where(p => p.filmId.ToString().StartsWith(diary1.filmId.ToString())).Count();

            if (_diary1 > 0) // ALREADY SEEDED
                return true;


            if (_diary1 == 0)
                try
                {
                    await diaryRepository.AddAsync(diary1);
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
