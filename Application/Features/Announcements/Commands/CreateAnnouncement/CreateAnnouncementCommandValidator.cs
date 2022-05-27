using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Announcements.Commands.CreateAnnouncement
{
    public class CreateAnnouncementCommandValidator : AbstractValidator<CreateAnnouncementCommand>
    {
        private readonly IAnnouncementRepositoryAsync _announcementRepository;

        public CreateAnnouncementCommandValidator(IAnnouncementRepositoryAsync announcementRepository)
        {
            _announcementRepository = announcementRepository;

            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull();
        }

    }
}
