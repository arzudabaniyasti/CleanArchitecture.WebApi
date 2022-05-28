using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WatchLists.Queries.GetAllWatchLists
{
    public class GetAllWatchListsQuery : IRequest<PagedResponse<IEnumerable<GetAllWatchListsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllWatchListsQueryHandler : IRequestHandler<GetAllWatchListsQuery, PagedResponse<IEnumerable<GetAllWatchListsViewModel>>>
    {
        private readonly IWatchListRepositoryAsync _watchListRepository;
        private readonly IMapper _mapper;
        public GetAllWatchListsQueryHandler(IWatchListRepositoryAsync watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllWatchListsViewModel>>> Handle(GetAllWatchListsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllWatchListsParameter>(request);

            var _watchList = await _watchListRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var watchListViewModel = _mapper.Map<IEnumerable<GetAllWatchListsViewModel>>(_watchList);
            return new PagedResponse<IEnumerable<GetAllWatchListsViewModel>>(watchListViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}