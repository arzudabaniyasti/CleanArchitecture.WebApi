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

namespace Application.Features.Personnels.Queries.GetPersonnelById
{
    public class GetPersonnelByIdQuery : IRequest<Response<Personnel>>
    {
        public int Id { get; set; }
        public class GetPersonnelByIdQueryHandler : IRequestHandler<GetPersonnelByIdQuery, Response<Personnel>>
        {
            private readonly IPersonnelRepositoryAsync _personnelRepository;
            public GetPersonnelByIdQueryHandler(IPersonnelRepositoryAsync personnelRepository)
            {
                _personnelRepository = personnelRepository;
            }
            public async Task<Response<Personnel>> Handle(GetPersonnelByIdQuery query, CancellationToken cancellationToken)
            {
                var personnel = await _personnelRepository.GetPersonnelByIdWithRelationsAsync(query.Id);
                if (personnel == null) throw new ApiException($"Personnel Not Found.");
                return new Response<Personnel>(personnel);
            }
        }
    }
}
