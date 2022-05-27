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

namespace Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Town { get; set; }

        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Response<int>>
        {
            private readonly IAddressRepositoryAsync _addressRepository;
            private readonly IMapper _mapper;
            public UpdateAddressCommandHandler(IAddressRepositoryAsync addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(command.Id);

                if (address == null)
                {
                    throw new ApiException($"Address Not Found.");
                }
                else
                {
                    //address.Name = command.Name;
                    //address.Street = command.Street;
                    //address.City = command.City;
                    //address.Town = command.Town;

                    address = _mapper.Map<Address>(command);
                    await _addressRepository.UpdateAsync(address);
                    return new Response<int>(address.Id);
                }
            }
        }
    }
}
