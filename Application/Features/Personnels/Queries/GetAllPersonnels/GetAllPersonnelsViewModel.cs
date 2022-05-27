using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Personnels.Queries.GetAllPersonnels
{
    public class GetAllPersonnelsViewModel
    {
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
