using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Announcements.Commands.DeleteAnnouncementById
{
    public class DeleteAnnouncementByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteAnnouncementByIdCommandHandler : IRequestHandler<DeleteAnnouncementByIdCommand, Response<int>>
        {
            private readonly IAnnouncementRepositoryAsync _announcementRepository;

            public DeleteAnnouncementByIdCommandHandler(IAnnouncementRepositoryAsync announcementRepository)
            {
                _announcementRepository = announcementRepository;
            }

            public async Task<Response<int>> Handle(DeleteAnnouncementByIdCommand request, CancellationToken cancellationToken)
            {
                var announcement = await _announcementRepository.GetByIdAsync(request.Id);
                if (announcement == null) throw new ApiException($"Announcement not found");
                await _announcementRepository.DeleteAsync(announcement);
                return new Response<int>(announcement.Id);
            }
        }
    }
}
