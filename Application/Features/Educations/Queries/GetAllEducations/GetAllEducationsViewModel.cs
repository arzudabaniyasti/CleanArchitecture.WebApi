using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Educations.Queries.GetAllEducations
{
    public class GetAllEducationsViewModel
    {
        public string CollegeName { get; set; }
        public string Major { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
