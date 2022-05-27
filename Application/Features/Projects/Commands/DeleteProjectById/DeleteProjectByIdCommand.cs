using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Commands.DeleteProjectById
{
    public class DeleteProjectByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public DeleteProjectByIdCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<int>> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(command.Id);
                if (project == null) throw new ApiException($"Project Not Found.");
                await _projectRepository.DeleteAsync(project);
                return new Response<int>(project.Id);
            }
        }
    }
}
