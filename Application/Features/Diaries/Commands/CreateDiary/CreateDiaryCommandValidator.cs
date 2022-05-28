using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Diaries.Commands.CreateDiaries
{
    public class CreateDiaryCommandValidator : AbstractValidator<CreateDiaryCommand>
    {
        private readonly IDiaryRepositoryAsync diaryRepository;

        public CreateDiaryCommandValidator(IDiaryRepositoryAsync diaryRepository)
        {
            this.diaryRepository = diaryRepository;

            RuleFor(p => p.addingDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.filmId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
