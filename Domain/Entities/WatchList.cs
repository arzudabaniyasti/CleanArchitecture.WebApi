using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WatchList : AuditableBaseEntity
    {
        public int? filmId { get; set; }
    }

}
