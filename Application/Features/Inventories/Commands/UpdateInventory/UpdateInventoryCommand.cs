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

namespace Application.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<Product> Products { get; set; } // I don't know if we will track products in inventory?
        //public ICollection<Personnel> InventoryStaf { get; set; }
        //public ICollection<Address> Warehouses { get; set; }

        public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, Response<int>>
        {
            private readonly IInventoryRepositoryAsync _inventoryRepository;
            private readonly IMapper _mapper;
            public UpdateInventoryCommandHandler(IInventoryRepositoryAsync inventoryRepository, IMapper mapper)
            {
                _inventoryRepository = inventoryRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateInventoryCommand command, CancellationToken cancellationToken)
            {
                var inventory = await _inventoryRepository.GetByIdAsync(command.Id);

                if (inventory == null)
                {
                    throw new ApiException($"Inventory Not Found.");
                }
                else
                {
                    inventory = _mapper.Map<Inventory>(command);
                    await _inventoryRepository.UpdateAsync(inventory);
                    return new Response<int>(inventory.Id);
                }
            }
        }
    }
}
