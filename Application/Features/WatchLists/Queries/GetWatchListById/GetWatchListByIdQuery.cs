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

namespace Application.Features.WatchLists.Queries.GetWatchListById
{
    public class GetWatchListByIdQuery : IRequest<Response<WatchList>>
    {
        public int Id { get; set; }
        public class GetWatchListByIdQueryHandler : IRequestHandler<GetWatchListByIdQuery, Response<WatchList>>
        {
            private readonly IWatchListRepositoryAsync _watchListRepository;
            public GetWatchListByIdQueryHandler(IWatchListRepositoryAsync watchListRepository)
            {
                _watchListRepository = watchListRepository;
            }
            public async Task<Response<WatchList>> Handle(GetWatchListByIdQuery query, CancellationToken cancellationToken)
            {
                var watchList = await _watchListRepository.GetByIdAsync(query.Id);
                if (watchList == null) throw new ApiException($"Watch List Not Found.");
                return new Response<WatchList>(watchList);
            }
        }
    }
}