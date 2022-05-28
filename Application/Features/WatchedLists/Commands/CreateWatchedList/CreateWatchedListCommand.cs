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

namespace Application.Features.WatchedLists.Commands.CreateWatchedList
{
    public partial class CreateWatchedListCommand : IRequest<Response<int>>
    {
        public int? filmId { get; set; }
    }
    public class CreateWatchedListCommandHandler : IRequestHandler<CreateWatchedListCommand, Response<int>>
    {
        private readonly IWatchedListRepositoryAsync _watchedListRepository;
        private readonly IMapper _mapper;
        public CreateWatchedListCommandHandler(IWatchedListRepositoryAsync watchedListRepository, IMapper mapper)
        {
            _watchedListRepository = watchedListRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWatchedListCommand request, CancellationToken cancellationToken)
        {
            var watchedList = _mapper.Map<WatchedList>(request);
            await _watchedListRepository.AddAsync(watchedList);
            return new Response<int>(watchedList.Id);
        }
    }

}