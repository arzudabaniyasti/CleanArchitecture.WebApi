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

namespace Application.Features.WorkHistories.Commands.UpdateWorkHistory
{
    public class UpdateWorkHistoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public class UpdateWorkHistoryCommandHandler : IRequestHandler<UpdateWorkHistoryCommand, Response<int>>
        {
            private readonly IWorkHistoryRepositoryAsync _workHistoryRepository;
            private readonly IMapper _mapper;
            public UpdateWorkHistoryCommandHandler(IWorkHistoryRepositoryAsync workHistoryRepository, IMapper mapper)
            {
                _workHistoryRepository = workHistoryRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateWorkHistoryCommand command, CancellationToken cancellationToken)
            {
                var workHistory = await _workHistoryRepository.GetByIdAsync(command.Id);

                if (workHistory == null)
                {
                    throw new ApiException($"WorkHistory Not Found.");
                }
                else
                {
                    workHistory = _mapper.Map<WorkHistory>(command);
                    await _workHistoryRepository.UpdateAsync(workHistory);
                    return new Response<int>(workHistory.Id);
                }
            }
        }
    }
}
