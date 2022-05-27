using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkHistories.Commands.CreateWorkHistory
{
    public partial class CreateWorkHistoryCommand : IRequest<Response<int>>
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateWorkHistoryCommandHandler : IRequestHandler<CreateWorkHistoryCommand, Response<int>>
    {
        private readonly IWorkHistoryRepositoryAsync _workHistoryRepository;
        private readonly IMapper _mapper;
        public CreateWorkHistoryCommandHandler(IWorkHistoryRepositoryAsync workHistoryRepository, IMapper mapper)
        {
            _workHistoryRepository = workHistoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWorkHistoryCommand request, CancellationToken cancellationToken)
        {
            var workHistory = _mapper.Map<WorkHistory>(request);
            await _workHistoryRepository.AddAsync(workHistory);
            return new Response<int>(workHistory.Id);
        }
    }
}
