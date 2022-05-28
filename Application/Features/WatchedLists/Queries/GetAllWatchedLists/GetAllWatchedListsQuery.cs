using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WatchedLists.Queries.GetAllWatchedLists
{
    public class GetAllWatchedListsQuery : IRequest<PagedResponse<IEnumerable<GetAllWatchedListsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllWatchedListsQueryHandler : IRequestHandler<GetAllWatchedListsQuery, PagedResponse<IEnumerable<GetAllWatchedListsViewModel>>>
    {
        private readonly IWatchedListRepositoryAsync _watchedListRepository;
        private readonly IMapper _mapper;
        public GetAllWatchedListsQueryHandler(IWatchedListRepositoryAsync watchedListRepository, IMapper mapper)
        {
            _watchedListRepository = watchedListRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllWatchedListsViewModel>>> Handle(GetAllWatchedListsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllWatchedListsParameter>(request);

            var _watchedList = await _watchedListRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var watchedListViewModel = _mapper.Map<IEnumerable<GetAllWatchedListsViewModel>>(_watchedList);
            return new PagedResponse<IEnumerable<GetAllWatchedListsViewModel>>(watchedListViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
