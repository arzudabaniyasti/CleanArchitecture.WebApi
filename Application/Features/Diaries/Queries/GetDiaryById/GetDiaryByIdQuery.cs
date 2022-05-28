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

namespace Application.Features.Diaries.Queries.GetDiaryById
{
    public class GetDiaryByIdQuery : IRequest<Response<Diary>>
    {
        public int Id { get; set; }
        public class GetDiaryByIdQueryHandler : IRequestHandler<GetDiaryByIdQuery, Response<Diary>>
        {
            private readonly IDiaryRepositoryAsync _diaryRepository;
            public GetDiaryByIdQueryHandler(IDiaryRepositoryAsync diaryRepository)
            {
                _diaryRepository = diaryRepository;
            }
            public async Task<Response<Diary>> Handle(GetDiaryByIdQuery query, CancellationToken cancellationToken)
            {
                var diary = await _diaryRepository.GetByIdAsync(query.Id);
                if (diary == null) throw new ApiException($"Diary Not Found.");
                return new Response<Diary>(diary);
            }
        }
    }
}