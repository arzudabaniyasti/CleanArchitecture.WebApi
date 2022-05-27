using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Inventories.Queries.GetAllInventories
{
    public class GetAllInventoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllInventoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllInventoriesQueryHandler : IRequestHandler<GetAllInventoriesQuery, PagedResponse<IEnumerable<GetAllInventoriesViewModel>>>
    {
        private readonly IInventoryRepositoryAsync _inventoryRepository;
        private readonly IMapper _mapper;
        public GetAllInventoriesQueryHandler(IInventoryRepositoryAsync inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllInventoriesViewModel>>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllInventoriesParameter>(request);

            var inventory = await _inventoryRepository.GetInventoriesWithProductAsync(validFilter.PageNumber, validFilter.PageSize);
                
              //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var inventoryViewModel = _mapper.Map<IEnumerable<GetAllInventoriesViewModel>>(inventory);
            return new PagedResponse<IEnumerable<GetAllInventoriesViewModel>>(inventoryViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
