using Application.Exceptions;
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

namespace Application.Features.Announcements.Commands.UpdateAnnouncement
{
    public class UpdateAnnouncementCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string Attachment { get; set; }
        public string Company { get; set; }
        public string Letter { get; set; }

        public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, Response<int>>
        {

            private readonly IAnnouncementRepositoryAsync _announcementRepository;
            private readonly IMapper _mapper;

            public UpdateAnnouncementCommandHandler(IAnnouncementRepositoryAsync announcementRepository, IMapper mapper)
            {
                _announcementRepository = announcementRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
            {
                var announcement = await _announcementRepository.GetByIdAsync(request.Id);

                if (announcement == null) throw new ApiException($"Announcement Not Found");
                else
                {
                    announcement = _mapper.Map<Announcement>(request);
                    await _announcementRepository.UpdateAsync(announcement);
                    return new Response<int>(announcement.Id);
                }
            }
        }
    }
}
