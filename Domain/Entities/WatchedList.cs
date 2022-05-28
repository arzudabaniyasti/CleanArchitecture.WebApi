using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WatchedList : AuditableBaseEntity
    {
        public int? filmId { get; set; }
    }
}
