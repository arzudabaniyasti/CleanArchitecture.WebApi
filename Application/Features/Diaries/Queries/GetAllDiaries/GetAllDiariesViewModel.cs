using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Diaries.Queries.GetAllDiaries
{
    public class GetAllDiariesViewModel
    {

        public int? filmId { get; set; }
        public DateTime addingDate { get; set; }

        public double userRating { get; set; }
    }
}
