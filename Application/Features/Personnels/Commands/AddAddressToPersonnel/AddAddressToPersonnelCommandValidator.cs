﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personnels.Commands.AddAddressToPersonnel
{
    public class AddAddressToPersonnelCommandValidator : AbstractValidator<AddAddressToPersonnelCommand>
    {
        private readonly IPersonnelRepositoryAsync personnelRepository;

        public AddAddressToPersonnelCommandValidator(IPersonnelRepositoryAsync personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }
    }
}
