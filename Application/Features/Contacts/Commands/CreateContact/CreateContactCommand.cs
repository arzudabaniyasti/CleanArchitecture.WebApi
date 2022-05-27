using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Contacts.Commands.CreateContact
{
    public partial class CreateContactCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<int>>
    {
        private readonly IContactRepositoryAsync _contactRepository;
        private readonly IMapper _mapper;
        public CreateContactCommandHandler(IContactRepositoryAsync contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);
            await _contactRepository.AddAsync(contact);
            return new Response<int>(contact.Id);
        }
    }
}
