using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public int? PersonnelId { get; set; }
        public int? EventId { get; set; }
    }
}
