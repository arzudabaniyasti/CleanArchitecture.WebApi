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

namespace Application.Features.Certificates.Commands.CreateCertificate
{
    public class CreateCertificateCommandValidator : AbstractValidator<CreateCertificateCommand>
    {
        private readonly ICertificateRepositoryAsync certificateRepository;

        public CreateCertificateCommandValidator(ICertificateRepositoryAsync certificateRepository)
        {
            this.certificateRepository = certificateRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                
        }
    }
}
