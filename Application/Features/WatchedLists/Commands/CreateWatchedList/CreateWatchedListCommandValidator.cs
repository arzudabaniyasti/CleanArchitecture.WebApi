using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.WatchedLists.Commands.CreateWatchedList
{
    public class CreateWatchedListCommandValidator : AbstractValidator<CreateWatchedListCommand>
    {
        private readonly IWatchedListRepositoryAsync watchedListRepository;

        public CreateWatchedListCommandValidator(IWatchedListRepositoryAsync watchedListRepository)
        {
            this.watchedListRepository = watchedListRepository;

            RuleFor(p => p.filmId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
         
        }
    }
}

