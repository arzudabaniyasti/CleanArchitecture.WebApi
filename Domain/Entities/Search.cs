using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Search : AuditableBaseEntity
    {
        public string searchContent { get; set; }
       
    }    
}
