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

namespace Application.Features.Educations.Commands.CreateEducation
{
    public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
    {
        private readonly IEducationRepositoryAsync educationRepository;

        public CreateEducationCommandValidator(IEducationRepositoryAsync educationRepository)
        {
            this.educationRepository = educationRepository;

           
            RuleFor(p => p.CollegeName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

       /* private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await productRepository.IsUniqueBarcodeAsync(barcode);
        }*/
    }
}
