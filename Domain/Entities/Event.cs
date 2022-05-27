using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Event : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Personnel> Participants { get; set; }
        public virtual Address Venue { get; set; }
        public string State { get; set; }
    }
}
