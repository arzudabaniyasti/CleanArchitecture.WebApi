using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Diaries.Queries.GetAllDiaries
{
    public class GetAllDiariesQuery : IRequest<PagedResponse<IEnumerable<GetAllDiariesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllDiariesQueryHandler : IRequestHandler<GetAllDiariesQuery, PagedResponse<IEnumerable<GetAllDiariesViewModel>>>
    {
        private readonly IDiaryRepositoryAsync _diaryRepository;
        private readonly IMapper _mapper;
        public GetAllDiariesQueryHandler(IDiaryRepositoryAsync diaryRepository, IMapper mapper)
        {
            _diaryRepository = diaryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllDiariesViewModel>>> Handle(GetAllDiariesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllDiariesParameter>(request);

            var _diary = await _diaryRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var diaryViewModel = _mapper.Map<IEnumerable<GetAllDiariesViewModel>>(_diary);
            return new PagedResponse<IEnumerable<GetAllDiariesViewModel>>(diaryViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}