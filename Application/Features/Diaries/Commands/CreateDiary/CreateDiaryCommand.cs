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

namespace Application.Features.Diaries.Commands.CreateDiaries
{
    public partial class CreateDiaryCommand : IRequest<Response<int>>
    {
        public int? filmId { get; set; }
        public DateTime addingDate { get; set; }

        public double userRating { get; set; }
    }
    public class CreateDiaryCommandHandler : IRequestHandler<CreateDiaryCommand, Response<int>>
    {
        private readonly IDiaryRepositoryAsync _diaryRepository;
        private readonly IMapper _mapper;
        public CreateDiaryCommandHandler(IDiaryRepositoryAsync diaryRepository, IMapper mapper)
        {
            _diaryRepository = diaryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDiaryCommand request, CancellationToken cancellationToken)
        {
            var diary = _mapper.Map<Diary>(request);
            await _diaryRepository.AddAsync(diary);
            return new Response<int>(diary.Id);
        }
    }

}
