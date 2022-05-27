using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Announcements.Queries.GetAllAnnouncements
{
    public class GetAllAnnouncementsViewModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string Attachment { get; set; }
        public string Company { get; set; }
        public string Letter { get; set; }
    }
}
