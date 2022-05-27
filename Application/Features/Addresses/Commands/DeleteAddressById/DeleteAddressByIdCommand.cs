using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.DeleteAddressById
{
    public class DeleteAddressByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteAddressByIdCommandHandler : IRequestHandler<DeleteAddressByIdCommand, Response<int>>
        {
            private readonly IAddressRepositoryAsync _addressRepository;
            public DeleteAddressByIdCommandHandler(IAddressRepositoryAsync addressRepository)
            {
                _addressRepository = addressRepository;
            }
            public async Task<Response<int>> Handle(DeleteAddressByIdCommand command, CancellationToken cancellationToken)
            {
                var address = await _addressRepository.GetByIdAsync(command.Id);
                if (address == null) throw new ApiException($"Address Not Found.");
                await _addressRepository.DeleteAsync(address);
                return new Response<int>(address.Id);
            }
        }
    }
}
