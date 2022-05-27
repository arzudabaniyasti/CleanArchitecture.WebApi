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

namespace Application.Features.Events.Commands.AddAddressToEvent
{
    public class AddAddressToEventCommandValidator : AbstractValidator<AddAddressToEventCommand>
    {
        private readonly IEventRepositoryAsync eventRepository;

        public AddAddressToEventCommandValidator(IEventRepositoryAsync eventRepository)
        {
            this.eventRepository = eventRepository;
        }
    }
}
