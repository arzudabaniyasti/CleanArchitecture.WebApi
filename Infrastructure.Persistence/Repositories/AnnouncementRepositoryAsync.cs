using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class AnnouncementRepositoryAsync : GenericRepositoryAsync<Announcement>, IAnnouncementRepositoryAsync
    {
        private readonly DbSet<Announcement> _announcements;
        public AnnouncementRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _announcements = dbContext.Set<Announcement>();
        }
    }
}
