using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Town { get; set; }

    }
}
