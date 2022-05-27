using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Educations.Commands.DeleteEducationById
{
    public class DeleteEducationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteEducationByIdCommandHandler : IRequestHandler<DeleteEducationByIdCommand, Response<int>>
        {
            private readonly IEducationRepositoryAsync _educationRepository;
            public DeleteEducationByIdCommandHandler(IEducationRepositoryAsync educationRepository)
            {
                _educationRepository = educationRepository;
            }
            public async Task<Response<int>> Handle(DeleteEducationByIdCommand command, CancellationToken cancellationToken)
            {
                var education = await _educationRepository.GetByIdAsync(command.Id);
                if (education == null) throw new ApiException($"Education Not Found.");
                await _educationRepository.DeleteAsync(education);
                return new Response<int>(education.Id);
            }
        }
    }
}
