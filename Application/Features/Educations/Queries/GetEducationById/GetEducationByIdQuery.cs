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

namespace Application.Features.Educations.Queries.GetEducationById
{
    public class GetEducationByIdQuery : IRequest<Response<Education>>
    {
        public int Id { get; set; }
        public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, Response<Education>>
        {
            private readonly IEducationRepositoryAsync _educationRepository;
            public GetEducationByIdQueryHandler(IEducationRepositoryAsync educationRepository)
            {
                _educationRepository = educationRepository;
            }
            public async Task<Response<Education>> Handle(GetEducationByIdQuery query, CancellationToken cancellationToken)
            {
                var education = await _educationRepository.GetByIdAsync(query.Id);
                if (education == null) throw new ApiException($"Education Not Found.");
                return new Response<Education>(education);
            }
        }
    }
}
