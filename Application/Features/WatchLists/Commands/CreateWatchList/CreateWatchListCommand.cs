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

namespace Application.Features.WatchLists.Commands.CreateWatchList
{
    public partial class CreateWatchListCommand : IRequest<Response<int>>
    {
        public int? filmId { get; set; }
    }
    public class CreateWatchListCommandHandler : IRequestHandler<CreateWatchListCommand, Response<int>>
    {
        private readonly IWatchListRepositoryAsync _watchListRepository;
        private readonly IMapper _mapper;
        public CreateWatchListCommandHandler(IWatchListRepositoryAsync watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWatchListCommand request, CancellationToken cancellationToken)
        {
            var watchList = _mapper.Map<WatchList>(request);
            await _watchListRepository.AddAsync(watchList);
            return new Response<int>(watchList.Id);
        }
    }

}
