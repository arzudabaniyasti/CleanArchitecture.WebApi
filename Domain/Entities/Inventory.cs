using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Inventory : AuditableBaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } // I don't know if we will track products in inventory?
    }
}
