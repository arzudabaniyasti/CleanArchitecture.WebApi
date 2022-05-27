using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Events.Queries.GetAllEvents
{
    public class GetAllEventsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Personnel> Participants { get; set; }
        public virtual Address Venue { get; set; }
        public string State { get; set; }
    }
}
