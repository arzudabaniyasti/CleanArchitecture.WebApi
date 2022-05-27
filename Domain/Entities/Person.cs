using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }//get ve sete izin veriyor.
        public int? Height { get; set; }//nul olabilir demek ? olmasý.

        /*public Person Mother { get; set; }
        public Person Father { get; set; }*/
        
    }
}
