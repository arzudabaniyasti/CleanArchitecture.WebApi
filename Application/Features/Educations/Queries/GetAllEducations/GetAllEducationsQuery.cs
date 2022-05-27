using Application.Features.Educations.Queries.GetAllEducations;
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

namespace Application.Features.Educations.Queries.GetAllEducations
{
    public class GetAllEducationsQuery : IRequest<PagedResponse<IEnumerable<GetAllEducationsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllEducationsQueryHandler : IRequestHandler<GetAllEducationsQuery, PagedResponse<IEnumerable<GetAllEducationsViewModel>>>
    {
        private readonly IEducationRepositoryAsync _educationRepository;
        private readonly IMapper _mapper;
        public GetAllEducationsQueryHandler(IEducationRepositoryAsync educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllEducationsViewModel>>> Handle(GetAllEducationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllEducationsParamater>(request);
            var education = await _educationRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var educationViewModel = _mapper.Map<IEnumerable<GetAllEducationsViewModel>>(education);
            return new PagedResponse<IEnumerable<GetAllEducationsViewModel>>(educationViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
