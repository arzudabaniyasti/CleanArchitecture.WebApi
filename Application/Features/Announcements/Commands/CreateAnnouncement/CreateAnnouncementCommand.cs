using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Announcements.Commands.CreateAnnouncement
{
    public partial class CreateAnnouncementCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string Attachment { get; set; }
        public string Company { get; set; }
        public string Letter { get; set; }
    }

    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, Response<int>>
    {
        private readonly IAnnouncementRepositoryAsync _announcementRepository;
        private readonly IMapper _mapper;

        public CreateAnnouncementCommandHandler(IAnnouncementRepositoryAsync announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = _mapper.Map<Announcement>(request);
            await _announcementRepository.AddAsync(announcement);
            return new Response<int>(announcement.Id);
        }
    }
}
