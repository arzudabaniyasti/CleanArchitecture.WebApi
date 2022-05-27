using Application.Features.Educations.Queries.GetAllEducations;
using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Films.Queries.GetAllFilms
{
    public class GetAllFilmsQuery : IRequest<PagedResponse<IEnumerable<GetAllFilmsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFilmsQueryHandler : IRequestHandler<GetAllFilmsQuery, PagedResponse<IEnumerable<GetAllFilmsViewModel>>>
    {
        private readonly IFilmmRepositoryAsync _filmRepository;
        private readonly IMapper _mapper;
        public GetAllFilmsQueryHandler(IFilmmRepositoryAsync filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFilmsViewModel>>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFilmsParameter>(request);

            var _film = await _filmRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            //  GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var filmViewModel = _mapper.Map<IEnumerable<GetAllFilmsViewModel>>(_film);
            return new PagedResponse<IEnumerable<GetAllFilmsViewModel>>(filmViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
