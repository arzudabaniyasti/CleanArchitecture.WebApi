using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<PagedResponse<IEnumerable<GetAllEventsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, PagedResponse<IEnumerable<GetAllEventsViewModel>>>
    {
        private readonly IEventRepositoryAsync _eventRepository;
        private readonly IMapper _mapper;
        public GetAllEventsQueryHandler(IEventRepositoryAsync eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllEventsViewModel>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllEventsParameter>(request);
            var _event = await _eventRepository.GetEventsWithRelationsAsync(validFilter.PageNumber, validFilter.PageSize);
            var eventViewModel = _mapper.Map<IEnumerable<GetAllEventsViewModel>>(_event);
            return new PagedResponse<IEnumerable<GetAllEventsViewModel>>(eventViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
