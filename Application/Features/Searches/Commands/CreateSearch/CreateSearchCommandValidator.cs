using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Searches.Commands.CreateSearch
{
    public class CreateSearchCommandValidator : AbstractValidator<CreateSearchCommand>
    {
        private readonly ISearchRepositoryAsync searchRepository;

        public CreateSearchCommandValidator(ISearchRepositoryAsync searchRepository)
        {
            this.searchRepository = searchRepository;

            RuleFor(p => p.searchContent)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}
