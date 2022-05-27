using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Contact: AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


    }
}
