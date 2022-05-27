using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Announcements.Queries.GetAnnouncementById
{
    public class GetAnnouncementByIdQuery : IRequest<Response<Announcement>>
    {
        public int Id { get; set; }

        public class GetAnnouncementByIdQueryHandler : IRequestHandler<GetAnnouncementByIdQuery, Response<Announcement>>
        {
            private readonly IAnnouncementRepositoryAsync _announcementRepository;

            public GetAnnouncementByIdQueryHandler(IAnnouncementRepositoryAsync announcementRepository)
            {
                _announcementRepository = announcementRepository;
            }

            public async Task<Response<Announcement>> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
            {
                var announcement = await _announcementRepository.GetByIdAsync(request.Id);
                if (announcement == null) throw new ApiException($"Announcelment not found");
                return new Response<Announcement>(announcement);
            }
        }
    }
}
