using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personnels.Commands.AddAddressToPersonnel
{
    public partial class AddAddressToPersonnelCommand : IRequest<Response<int>>
    {
        public int PersonnelId { get; set; }
        public int AddressId { get; set; }
    }
    public class AddAddressToPersonnelCommandHandler : IRequestHandler<AddAddressToPersonnelCommand, Response<int>>
    {
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly IAddressRepositoryAsync _addressRepository;
        private readonly IMapper _mapper;

        public AddAddressToPersonnelCommandHandler(IPersonnelRepositoryAsync personnelRepository, IAddressRepositoryAsync addressRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddAddressToPersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.GetByIdAsync(request.PersonnelId);
            if (personnel == null) return null;

            var address = await _addressRepository.GetByIdAsync(request.AddressId);
            if (address == null) return null;

            address.PersonnelId = personnel.Id;

            await _addressRepository.UpdateAsync(address);

            return new Response<int>(personnel.Id);
        }

    }
}
