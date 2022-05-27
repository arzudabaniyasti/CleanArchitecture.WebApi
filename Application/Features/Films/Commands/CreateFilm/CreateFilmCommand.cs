using Application.Features.Films.Commands.CreateFilm;
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

namespace Application.Features.Films.Commands.CreateFilm
{
    public partial class CreateFilmCommand : IRequest<Response<int>>
    {
        public string filmName { get; set; }
        public int releaseYear { get; set; }
        public string genre { get; set; }
        public string filmBrief { get; set; }
        public double filmRating { get; set; }
        public int duration { get; set; }
        public string filmPoster { get; set; }
        public string trailer { get; set; }
    }
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Response<int>>
    {
        private readonly IFilmmRepositoryAsync _filmRepository;
        private readonly IMapper _mapper;
        public CreateFilmCommandHandler(IFilmmRepositoryAsync filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = _mapper.Map<Film>(request);
            await _filmRepository.AddAsync(film);
            return new Response<int>(film.Id);
        }
    }

}
