using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Responsibility { get; set; }
        public string TeamSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technology { get; set; }
    }
}
