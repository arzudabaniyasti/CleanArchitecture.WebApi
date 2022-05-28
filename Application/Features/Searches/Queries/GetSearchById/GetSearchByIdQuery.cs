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

namespace Application.Features.Searches.Queries.GetSearchById
{
    public class GetSearchByIdQuery : IRequest<Response<Search>>
    {
        public int Id { get; set; }
        public class GetSearchByIdQueryHandler : IRequestHandler<GetSearchByIdQuery, Response<Search>>
        {
            private readonly ISearchRepositoryAsync _searchRepository;
            public GetSearchByIdQueryHandler(ISearchRepositoryAsync searchRepository)
            {
                _searchRepository = searchRepository;
            }
            public async Task<Response<Search>> Handle(GetSearchByIdQuery query, CancellationToken cancellationToken)
            {
                var search = await _searchRepository.GetByIdAsync(query.Id);
                if (search == null) throw new ApiException($"Search Not Found.");
                return new Response<Search>(search);
            }
        }
    }
}
