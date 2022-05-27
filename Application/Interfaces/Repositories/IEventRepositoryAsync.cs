using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IEventRepositoryAsync : IGenericRepositoryAsync<Event>
    {
        public Task<IReadOnlyList<Event>> GetEventsWithRelationsAsync(int pageNumber, int pageSize);
        public Task<Event> GetEventByIdWithRelationsAsync(int eventId);
    }
}
