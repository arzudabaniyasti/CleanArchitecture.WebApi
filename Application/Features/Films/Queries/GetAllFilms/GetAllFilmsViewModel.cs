using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Films.Queries.GetAllFilms
{
    public class GetAllFilmsViewModel
    {
        public string filmName { get; set; }
        public int releaseYear { get; set; }
        public string genre { get; set; }
        public string filmBrief { get; set; }
        public double filmRating { get; set; }
        public int duration { get; set; }
        public string filmPoster { get; set; }
        public string trailer { get; set; }
    }
}
