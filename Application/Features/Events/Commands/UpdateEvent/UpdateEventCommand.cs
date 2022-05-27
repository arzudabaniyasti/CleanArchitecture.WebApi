using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Response<int>>
        {
            private readonly IEventRepositoryAsync _eventRepository;
            private readonly IMapper _mapper;
            public UpdateEventCommandHandler(IEventRepositoryAsync eventRepository, IMapper mapper)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var _event = await _eventRepository.GetByIdAsync(request.Id);

                if (_event == null)
                {
                    throw new ApiException($"Event Not Found.");
                }
                else
                {
                    _event = _mapper.Map<Event>(request);
                    await _eventRepository.UpdateAsync(_event);
                    return new Response<int>(_event.Id);
                }
            }
        }
    }
}
