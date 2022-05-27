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

namespace Application.Features.Personnels.Commands.CreatePersonnel
{
    public class CreatePersonnelCommandValidator : AbstractValidator<CreatePersonnelCommand>
    {
        private readonly IPersonnelRepositoryAsync personnelRepository;

        public CreatePersonnelCommandValidator(IPersonnelRepositoryAsync personnelRepository)
        {
            this.personnelRepository = personnelRepository;

            //RuleFor(p => p.FirstName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}
