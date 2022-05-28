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

namespace Application.Features.Searches.Commands.CreateSearch
{
    public partial class CreateSearchCommand : IRequest<Response<int>>
    {
        public string searchContent { get; set; }
    }
    public class CreateSearchCommandHandler : IRequestHandler<CreateSearchCommand, Response<int>>
    {
        private readonly ISearchRepositoryAsync _searchRepository;
        private readonly IMapper _mapper;
        public CreateSearchCommandHandler(ISearchRepositoryAsync searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSearchCommand request, CancellationToken cancellationToken)
        {
            var search = _mapper.Map<Search>(request);
            await _searchRepository.AddAsync(search);
            return new Response<int>(search.Id);
        }
    }

}
