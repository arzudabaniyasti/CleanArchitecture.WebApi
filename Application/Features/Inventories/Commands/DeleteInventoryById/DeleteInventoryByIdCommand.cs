using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Inventories.Commands.DeleteInventoryById
{
    public class DeleteInventoryByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteInventoryByIdCommandHandler : IRequestHandler<DeleteInventoryByIdCommand, Response<int>>
        {
            private readonly IInventoryRepositoryAsync _inventoryRepository;
            public DeleteInventoryByIdCommandHandler(IInventoryRepositoryAsync inventoryRepository)
            {
                _inventoryRepository = inventoryRepository;
            }
            public async Task<Response<int>> Handle(DeleteInventoryByIdCommand command, CancellationToken cancellationToken)
            {
                var inventory = await _inventoryRepository.GetByIdAsync(command.Id);
                if (inventory == null) throw new ApiException($"Inventory Not Found.");
                await _inventoryRepository.DeleteAsync(inventory);
                return new Response<int>(inventory.Id);
            }
        }
    }
}
