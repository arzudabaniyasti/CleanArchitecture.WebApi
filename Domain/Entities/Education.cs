using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Education : AuditableBaseEntity
    {
        public string CollegeName { get; set; }
        public string Major { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? PersonnelId { get; set; }
    }
}
