using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Certificates.Queries.GetAllCertificates
{
    public class GetAllCertificatesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
