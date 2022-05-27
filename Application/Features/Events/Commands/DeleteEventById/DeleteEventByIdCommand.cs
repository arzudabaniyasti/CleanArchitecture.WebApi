using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.DeleteEventById
{
    public class DeleteEventByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteEventByIdCommandHandler : IRequestHandler<DeleteEventByIdCommand, Response<int>>
        {
            private readonly IEventRepositoryAsync _eventRepository;
            public DeleteEventByIdCommandHandler(IEventRepositoryAsync eventRepository)
            {
                _eventRepository = eventRepository;
            }
            public async Task<Response<int>> Handle(DeleteEventByIdCommand command, CancellationToken cancellationToken)
            {
                var _event = await _eventRepository.GetByIdAsync(command.Id);
                if (_event == null) throw new ApiException($"Event Not Found.");
                await _eventRepository.DeleteAsync(_event);
                return new Response<int>(_event.Id);
            }
        }
    }
}
