using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Project : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Responsibility { get; set; }
        public string TeamSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technology { get; set; }
    }
}
