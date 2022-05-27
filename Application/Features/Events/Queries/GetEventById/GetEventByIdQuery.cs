using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<Response<Event>>
    {
        public int Id { get; set; }
        public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Response<Event>>
        {
            private readonly IEventRepositoryAsync _eventRepository;
            public GetEventByIdQueryHandler(IEventRepositoryAsync eventRepository)
            {
                _eventRepository = eventRepository;
            }
            public async Task<Response<Event>> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
            {
                var _event = await _eventRepository.GetEventByIdWithRelationsAsync(query.Id);
                if (_event == null) throw new ApiException($"Event Not Found.");
                return new Response<Event>(_event);
            }
        }
    }
}
