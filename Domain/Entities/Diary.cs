using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Diary : AuditableBaseEntity
    {
        public int? filmId { get; set; }
        public DateTime addingDate { get; set; }

        public double userRating { get; set; }
    }
   
}
