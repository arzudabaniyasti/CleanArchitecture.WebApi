using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Inventories.Commands.CreateInventory
{
    public partial class CreateInventoryCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }

    }
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Response<int>>
    {
        private readonly IInventoryRepositoryAsync _inventoryRepository;
        private readonly IMapper _mapper;
        public CreateInventoryCommandHandler(IInventoryRepositoryAsync inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);
            await _inventoryRepository.AddAsync(inventory);
            return new Response<int>(inventory.Id);
        }
    }
}
