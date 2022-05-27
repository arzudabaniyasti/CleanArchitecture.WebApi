using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Films.Commands.CreateFilm
{
    public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
    {
        private readonly IFilmmRepositoryAsync filmRepository;

        public CreateFilmCommandValidator(IFilmmRepositoryAsync filmRepository)
        {
            this.filmRepository = filmRepository;

            RuleFor(p => p.filmName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.filmBrief)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.genre)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


        }
    }
}
