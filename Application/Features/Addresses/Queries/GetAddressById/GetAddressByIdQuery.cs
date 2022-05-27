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

namespace Application.Features.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<Response<Address>>
    {
        public int Id { get; set; }
        public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Response<Address>>
        {
            private readonly IAddressRepositoryAsync _addressRepository;
            public GetAddressByIdQueryHandler(IAddressRepositoryAsync addressRepository)
            {
                _addressRepository = addressRepository;
            }
            public async Task<Response<Address>> Handle(GetAddressByIdQuery query, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(query.Id);
                if (address == null) throw new ApiException($"Address Not Found.");
                return new Response<Address>(address);
            }
        }
    }
}
