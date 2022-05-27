using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Responsibility { get; set; }
        public string TeamSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Technology { get; set; }
        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            private readonly IMapper _mapper;
            public UpdateProjectCommandHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
            {
                _projectRepository = projectRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(request.Id);

                if (project == null)
                {
                    throw new ApiException($"Project Not Found.");
                }
                else
                {
                    project = _mapper.Map<Project>(request);
                    await _projectRepository.UpdateAsync(project);
                    return new Response<int>(project.Id);

                }
            }
        }
    }
}
