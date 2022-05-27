using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkHistories.Commands.DeleteWorkHistoryById
{
    public class DeleteWorkHistoryByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteWorkHistoryByIdCommandHandler : IRequestHandler<DeleteWorkHistoryByIdCommand, Response<int>>
        {
            private readonly IWorkHistoryRepositoryAsync _workHistoryRepository;
            public DeleteWorkHistoryByIdCommandHandler(IWorkHistoryRepositoryAsync workHistoryRepository)
            {
                _workHistoryRepository = workHistoryRepository;
            }
            public async Task<Response<int>> Handle(DeleteWorkHistoryByIdCommand command, CancellationToken cancellationToken)
            {
                var workHistory = await _workHistoryRepository.GetByIdAsync(command.Id);
                if (workHistory == null) throw new ApiException($"WorkHistory Not Found.");
                await _workHistoryRepository.DeleteAsync(workHistory);
                return new Response<int>(workHistory.Id);
            }
        }
    }
}
