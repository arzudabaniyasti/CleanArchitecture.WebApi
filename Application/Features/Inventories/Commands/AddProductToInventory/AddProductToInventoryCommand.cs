using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Inventories.Commands.CreateInventory
{
    public partial class AddProductToInventoryCommand : IRequest<Response<int>>
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        //public ICollection<Product> Products { get; set; } // I don't know if we will track products in inventory?
        //public ICollection<Personnel> InventoryStaf { get; set; }
        //public ICollection<Address> Warehouses { get; set; }
    }
    public class AddProductToInventoryCommandHandler : IRequestHandler<AddProductToInventoryCommand, Response<int>>
    {
        private readonly IInventoryRepositoryAsync _inventoryRepository;
        private readonly IProductRepositoryAsync _productRepository;

        private readonly IMapper _mapper;

        public AddProductToInventoryCommandHandler(IProductRepositoryAsync productRepository, IInventoryRepositoryAsync inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddProductToInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(request.InventoryId);
            if (inventory == null) return null;

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null) return null;

            //product.Inventory = inventory;
            product.InventoryId = inventory.Id;

            await _productRepository.UpdateAsync(product);

            
            //var product = _mapper.Map<Product>(request.Product);
            //inventory.Products.


            //product.Inventory = inventory;
            //var productUpdated=await _productRepository.AddAsync(product);
            

            return new Response<int>(inventory.Id);
        }
    }
}
