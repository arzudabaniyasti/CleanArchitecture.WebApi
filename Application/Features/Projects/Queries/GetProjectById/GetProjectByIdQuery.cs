using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<Response<Project>>
    {
        public int Id { get; set; }
        public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Response<Project>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public GetProjectByIdQueryHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<Project>> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(query.Id);
                if (project == null) throw new ApiException($"Project Not Found.");
                return new Response<Project>(project);
            }
        }
    }
}
