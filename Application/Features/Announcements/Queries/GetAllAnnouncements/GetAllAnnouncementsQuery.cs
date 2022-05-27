using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Announcements.Queries.GetAllAnnouncements
{
    public class GetAllAnnouncementsQuery : IRequest<PagedResponse<IEnumerable<GetAllAnnouncementsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllProjectsQueryHandler : IRequestHandler<GetAllAnnouncementsQuery, PagedResponse<IEnumerable<GetAllAnnouncementsViewModel>>>
        {
            private readonly IAnnouncementRepositoryAsync _announcementRepository;
            private readonly IMapper _mapper;

            public GetAllProjectsQueryHandler(IAnnouncementRepositoryAsync announcementRepository, IMapper mapper)
            {
                _announcementRepository = announcementRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<GetAllAnnouncementsViewModel>>> Handle(GetAllAnnouncementsQuery request, CancellationToken cancellationToken)
            {
                var validFilter = _mapper.Map<GetAllAnnouncementsParameter>(request);
                var announcements = await _announcementRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
                var announcementViewModel = _mapper.Map<IEnumerable<GetAllAnnouncementsViewModel>>(announcements);
                return new PagedResponse<IEnumerable<GetAllAnnouncementsViewModel>>(announcementViewModel, validFilter.PageNumber, validFilter.PageSize);

            }
        }
    }
}
