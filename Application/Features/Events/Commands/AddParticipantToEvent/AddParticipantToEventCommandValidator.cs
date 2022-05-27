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

namespace Application.Features.Events.Commands.AddParticipantToEvent
{
    public class AddParticipantToEventCommandValidator : AbstractValidator<AddParticipantToEventCommand>
    {
        private readonly IEventRepositoryAsync eventRepository;

        public AddParticipantToEventCommandValidator(IEventRepositoryAsync eventRepository)
        {
            this.eventRepository = eventRepository;
        }
    }
}
