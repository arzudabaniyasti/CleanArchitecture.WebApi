using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.WorkHistories.Commands.CreateWorkHistory
{
    public class CreateWorkHistoryCommandValidator : AbstractValidator<CreateWorkHistoryCommand>
    {
        private readonly IWorkHistoryRepositoryAsync workHistoryRepository;

        public CreateWorkHistoryCommandValidator(IWorkHistoryRepositoryAsync workHistoryRepository)
        {
            this.workHistoryRepository = workHistoryRepository;

            RuleFor(p => p.Position)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        }

        //private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    return await productRepository.IsUniqueBarcodeAsync(barcode);
        //}
    }
}
