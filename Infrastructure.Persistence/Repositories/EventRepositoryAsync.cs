using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class EventRepositoryAsync : GenericRepositoryAsync<Event>, IEventRepositoryAsync
    {
        private readonly DbSet<Event> _events;

        public EventRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _events = dbContext.Set<Event>();
        }

        public async Task<Event> GetEventByIdWithRelationsAsync(int eventId)
        {
            return await _events.Include(p => p.Venue).Include(p => p.Participants)
                .SingleOrDefaultAsync(x => x.Id == eventId);
        }

        public async Task<IReadOnlyList<Event>> GetEventsWithRelationsAsync(int pageNumber, int pageSize)
        {
            return await _events.Include(x => x.Venue)
                .Include(x => x.Participants)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
