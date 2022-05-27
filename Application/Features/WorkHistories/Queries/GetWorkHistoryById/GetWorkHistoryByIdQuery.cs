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

namespace Application.Features.WorkHistories.Queries.GetWorkHistoryById
{
    public class GetWorkHistoryByIdQuery : IRequest<Response<WorkHistory>>
    {
        public int Id { get; set; }
        public class GetWorkHistoryByIdQueryHandler : IRequestHandler<GetWorkHistoryByIdQuery, Response<WorkHistory>>
        {
            private readonly IWorkHistoryRepositoryAsync _workHistoryRepository;
            public GetWorkHistoryByIdQueryHandler(IWorkHistoryRepositoryAsync workHistoryRepository)
            {
                _workHistoryRepository = workHistoryRepository;
            }
            public async Task<Response<WorkHistory>> Handle(GetWorkHistoryByIdQuery query, CancellationToken cancellationToken)
            {
                var workHistory = await _workHistoryRepository.GetByIdAsync(query.Id);
                if (workHistory == null) throw new ApiException($"WorkHistory Not Found.");
                return new Response<WorkHistory>(workHistory);
            }
        }
    }
}
