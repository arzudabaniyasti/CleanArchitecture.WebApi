using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.CreateAddress
{
    public partial class CreateAddressCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Response<int>>
    {
        private readonly IAddressRepositoryAsync _addressRepository;
        private readonly IMapper _mapper;
        public CreateAddressCommandHandler(IAddressRepositoryAsync addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            await _addressRepository.AddAsync(address);
            return new Response<int>(address.Id);
        }
    }
}
