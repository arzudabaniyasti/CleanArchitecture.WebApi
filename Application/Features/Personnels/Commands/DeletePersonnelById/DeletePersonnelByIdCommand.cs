using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personnels.Commands.DeletePersonnelById
{
    public class DeletePersonnelByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeletePersonnelByIdCommandHandler : IRequestHandler<DeletePersonnelByIdCommand, Response<int>>
        {
            private readonly IPersonnelRepositoryAsync _personnelRepository;
            public DeletePersonnelByIdCommandHandler(IPersonnelRepositoryAsync personnelRepository)
            {
                _personnelRepository = personnelRepository;
            }
            public async Task<Response<int>> Handle(DeletePersonnelByIdCommand command, CancellationToken cancellationToken)
            {
                var personnel = await _personnelRepository.GetByIdAsync(command.Id);
                if (personnel == null) throw new ApiException($"Personnel Not Found.");
                await _personnelRepository.DeleteAsync(personnel);
                return new Response<int>(personnel.Id);
            }
        }
    }
}
