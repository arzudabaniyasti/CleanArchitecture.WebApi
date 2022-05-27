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

namespace Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Response<int>>
        {
            private readonly IContactRepositoryAsync _contactRepository;
            private readonly IMapper _mapper;
            public UpdateContactCommandHandler(IContactRepositoryAsync contactRepository, IMapper mapper)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = await _contactRepository.GetByIdAsync(request.Id);

                if (contact == null)
                {
                    throw new ApiException($"Contact Not Found.");
                }
                else
                {
                    contact = _mapper.Map<Contact>(request);

                    //certificate.Name = command.Name;
                    //certificate.Provider = command.Provider;
                    //certificate.StartDate = command.StartDate;
                    //certificate.EndDate = command.EndDate;
                    //certificate.PersonId = command.PersonId;
                    await _contactRepository.UpdateAsync(contact);
                    return new Response<int>(contact.Id);
                }
            }
        }
    }
}
