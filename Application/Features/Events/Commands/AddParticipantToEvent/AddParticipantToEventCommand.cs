using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.AddParticipantToEvent
{
    public partial class AddParticipantToEventCommand : IRequest<Response<int>>
    {
        public int EventId { get; set; }
        public int PersonnelId { get; set; }
    }
    public class AddParticipantToEventCommandHandler : IRequestHandler<AddParticipantToEventCommand, Response<int>>
    {
        private readonly IEventRepositoryAsync _eventRepository;
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly IMapper _mapper;

        public AddParticipantToEventCommandHandler(IPersonnelRepositoryAsync personnelRepository, IEventRepositoryAsync eventRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddParticipantToEventCommand request, CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.GetByIdAsync(request.PersonnelId);
            if (personnel == null) return null;

            var _event = await _eventRepository.GetByIdAsync(request.EventId);
            if (_event == null) return null;

            personnel.EventId = _event.Id;

            await _personnelRepository.UpdateAsync(personnel);

            return new Response<int>(_event.Id);
        }

    }
}
