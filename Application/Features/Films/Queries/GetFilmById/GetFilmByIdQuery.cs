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

namespace Application.Features.Films.Queries.GetFilmById
{
    public class GetFilmByIdQuery : IRequest<Response<Film>>
    {
        public int Id { get; set; }
        public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery,Response<Film>> 
        {
            private readonly IFilmmRepositoryAsync _filmRepository;
            public GetFilmByIdQueryHandler(IFilmmRepositoryAsync filmRepository)
            {
                _filmRepository = filmRepository;
            }
            public async Task<Response<Film>> Handle(GetFilmByIdQuery query, CancellationToken cancellationToken)
            {
                var film = await _filmRepository.GetByIdAsync(query.Id);
                if (film == null) throw new ApiException($"Film Not Found.");
                return new Response<Film>(film);
            }
        }
    }
}
