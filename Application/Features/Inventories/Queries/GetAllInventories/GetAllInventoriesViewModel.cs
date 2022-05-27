using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Inventories.Queries.GetAllInventories
{
    public class GetAllInventoriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } // I don't know if we will track products in inventory?
    }
}
