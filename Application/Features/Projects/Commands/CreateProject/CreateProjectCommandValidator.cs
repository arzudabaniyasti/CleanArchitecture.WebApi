using Application.Features.Products.Commands.CreateProject;
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

namespace Application.Features.Products.Commands.CreateProject
{
    public class CreateProjectCommandValidor : AbstractValidator<CreateProjectCommand>
    {
        private readonly IProjectRepositoryAsync _projectRepository;

        public CreateProjectCommandValidor(IProjectRepositoryAsync projectRepository)
        {
            _projectRepository = projectRepository;



            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

        //private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        //{
        //    return await projectRepository.IsUniqueBarcodeAsync(barcode);
        //}
    }
}
