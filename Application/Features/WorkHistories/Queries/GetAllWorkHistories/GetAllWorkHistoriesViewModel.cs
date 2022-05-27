using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WorkHistories.Queries.GetAllWorkHistories
{
    public class GetAllWorkHistoriesViewModel
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
