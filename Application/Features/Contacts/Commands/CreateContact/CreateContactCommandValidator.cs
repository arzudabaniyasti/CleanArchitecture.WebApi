using Application.Features.Contacts.Commands.CreateContact;
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

namespace Application.Features.Contacts.Commands.CreateContant
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        private readonly IContactRepositoryAsync contactRepository;

        public CreateContactCommandValidator(IContactRepositoryAsync contactRepository)
        {
            this.contactRepository = contactRepository;


            RuleFor(p => p.Name)
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
