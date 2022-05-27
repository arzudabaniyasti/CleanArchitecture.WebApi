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

namespace Application.Features.Personnels.Queries.GetAllPersonnels
{
    public class GetAllPersonnelsQuery : IRequest<PagedResponse<IEnumerable<GetAllPersonnelsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPersonnelsQueryHandler : IRequestHandler<GetAllPersonnelsQuery, PagedResponse<IEnumerable<GetAllPersonnelsViewModel>>>
    {
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly IMapper _mapper;
        public GetAllPersonnelsQueryHandler(IPersonnelRepositoryAsync personnelRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPersonnelsViewModel>>> Handle(GetAllPersonnelsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPersonnelsParameter>(request);
            var personnel = await _personnelRepository.GetPersonnelsWithRelationsAsync(validFilter.PageNumber, validFilter.PageSize);
            var personnelViewModel = _mapper.Map<IEnumerable<GetAllPersonnelsViewModel>>(personnel);
            return new PagedResponse<IEnumerable<GetAllPersonnelsViewModel>>(personnelViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
