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

namespace Application.Features.Inventories.Queries.GetInventoryById
{
    public class GetInventoryByIdQuery : IRequest<Response<Inventory>>
    {
        public int Id { get; set; }
        public class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, Response<Inventory>>
        {
            private readonly IInventoryRepositoryAsync _inventoryRepository;
            public GetInventoryByIdQueryHandler(IInventoryRepositoryAsync inventoryRepository)
            {
                _inventoryRepository = inventoryRepository;
            }
            public async Task<Response<Inventory>> Handle(GetInventoryByIdQuery query, CancellationToken cancellationToken)
            {
                //var inventory = await _inventoryRepository.GetByIdAsync(query.Id);
                //var inventory = await _inventoryRepository.GetInventoryWithProductAsync();
                var inventory = await _inventoryRepository.GetInventoryWithProductAsync(query.Id);
                if (inventory == null) throw new ApiException($"Inventory Not Found.");
                return new Response<Inventory>(inventory);
            }
        }
    }
}
