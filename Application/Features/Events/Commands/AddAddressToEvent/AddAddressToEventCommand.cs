using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.AddAddressToEvent
{
    public partial class AddAddressToEventCommand : IRequest<Response<int>>
    {
        public int EventId { get; set; }
        public int AddressId { get; set; }
    }
    public class AddAddressToEventCommandHandler : IRequestHandler<AddAddressToEventCommand, Response<int>>
    {
        private readonly IEventRepositoryAsync _eventRepository;
        private readonly IAddressRepositoryAsync _addressRepository;
        private readonly IMapper _mapper;

        public AddAddressToEventCommandHandler(IEventRepositoryAsync eventRepository, IAddressRepositoryAsync addressRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddAddressToEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _eventRepository.GetByIdAsync(request.EventId);
            if (_event == null) return null;

            var address = await _addressRepository.GetByIdAsync(request.AddressId);
            if (address == null) return null;

            address.EventId = _event.Id;

            await _addressRepository.UpdateAsync(address);

            return new Response<int>(_event.Id);
        }

    }
}
