using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WatchedLists.Queries.GetWatchedListById
{
    public class GetWatchedListByIdQuery : IRequest<Response<WatchedList>>
    {
        public int Id { get; set; }
        public class GetWatchedListByIdQueryHandler : IRequestHandler<GetWatchedListByIdQuery, Response<WatchedList>>
        {
            private readonly IWatchedListRepositoryAsync _watchedListRepository;
            public GetWatchedListByIdQueryHandler(IWatchedListRepositoryAsync watchedListRepository)
            {
                _watchedListRepository = watchedListRepository;
            }
            public async Task<Response<WatchedList>> Handle(GetWatchedListByIdQuery query, CancellationToken cancellationToken)
            {
                var watchedList = await _watchedListRepository.GetByIdAsync(query.Id);
                if (watchedList == null) throw new ApiException($"Watched List Not Found.");
                return new Response<WatchedList>(watchedList);
            }
        }
    }
}