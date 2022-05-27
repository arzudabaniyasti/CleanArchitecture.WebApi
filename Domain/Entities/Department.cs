using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Department : AuditableBaseEntity
    {
        public string name { get; set; }
        public int? ParentDepartmentID{ get; set; }
       
    }
}
