using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.CreateEvent
{
    public partial class CreateEventCommand: IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Response<int>>
    {
        private readonly IEventRepositoryAsync _eventRepository;
        private readonly IMapper _mapper;
        public CreateEventCommandHandler(IEventRepositoryAsync eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var _event = _mapper.Map<Event>(request);
            await _eventRepository.AddAsync(_event);
            return new Response<int>(_event.Id);
        }
    }
}
