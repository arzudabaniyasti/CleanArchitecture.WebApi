using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WatchLists.Commands.CreateWatchList
{
    public class CreateWatchListCommandValidator : AbstractValidator<CreateWatchListCommand>
    {
        private readonly IWatchListRepositoryAsync watchListRepository;

        public CreateWatchListCommandValidator(IWatchListRepositoryAsync watchListRepository)
        {
            this.watchListRepository = watchListRepository;

            RuleFor(p => p.filmId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
