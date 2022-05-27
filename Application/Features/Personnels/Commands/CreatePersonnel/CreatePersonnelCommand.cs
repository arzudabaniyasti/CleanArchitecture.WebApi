using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personnels.Commands.CreatePersonnel
{
    public class CreatePersonnelCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public int Weight { get; set; }
    }
    public class CreatePersonnelCommandHandler : IRequestHandler<CreatePersonnelCommand, Response<int>>
    {
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly IMapper _mapper;
        public CreatePersonnelCommandHandler(IPersonnelRepositoryAsync personnelRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = _mapper.Map<Personnel>(request);
            await _personnelRepository.AddAsync(personnel);
            return new Response<int>(personnel.Id);
        }
    }
}
