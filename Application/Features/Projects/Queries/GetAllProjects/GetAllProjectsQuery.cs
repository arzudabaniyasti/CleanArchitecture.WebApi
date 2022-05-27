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

namespace Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<PagedResponse<IEnumerable<GetAllProjectsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PagedResponse<IEnumerable<GetAllProjectsViewModel>>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        public GetAllProjectsQueryHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProjectsViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProjectsParameter>(request);
            var project = await _projectRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var projectViewModel = _mapper.Map<IEnumerable<GetAllProjectsViewModel>>(project);
            return new PagedResponse<IEnumerable<GetAllProjectsViewModel>>(projectViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
