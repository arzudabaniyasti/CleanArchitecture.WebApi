using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Searches.Queries.GetAllSearches
{
    public class GetAllSearchesQuery : IRequest<PagedResponse<IEnumerable<GetAllSearchesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllSearchesQueryHandler : IRequestHandler<GetAllSearchesQuery, PagedResponse<IEnumerable<GetAllSearchesViewModel>>>
    {
        private readonly ISearchRepositoryAsync _searchRepository;
        private readonly IMapper _mapper;
        public GetAllSearchesQueryHandler(ISearchRepositoryAsync searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllSearchesViewModel>>> Handle(GetAllSearchesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllSearchesParameter>(request);

            var _search = await _searchRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var searchViewModel = _mapper.Map<IEnumerable<GetAllSearchesViewModel>>(_search);
            return new PagedResponse<IEnumerable<GetAllSearchesViewModel>>(searchViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
