using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkHistories.Queries.GetAllWorkHistories
{
    public class GetAllWorkHistoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllWorkHistoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllWorkHistoriesQueryHandler : IRequestHandler<GetAllWorkHistoriesQuery, PagedResponse<IEnumerable<GetAllWorkHistoriesViewModel>>>
    {
        private readonly IWorkHistoryRepositoryAsync _workHistoryRepository;
        private readonly IMapper _mapper;
        public GetAllWorkHistoriesQueryHandler(IWorkHistoryRepositoryAsync workHistoryRepository, IMapper mapper)
        {
            _workHistoryRepository = workHistoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllWorkHistoriesViewModel>>> Handle(GetAllWorkHistoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllWorkHistoriesParameter>(request);
            var workHistory = await _workHistoryRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var workHistoryViewModel = _mapper.Map<IEnumerable<GetAllWorkHistoriesViewModel>>(workHistory);
            return new PagedResponse<IEnumerable<GetAllWorkHistoriesViewModel>>(workHistoryViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
