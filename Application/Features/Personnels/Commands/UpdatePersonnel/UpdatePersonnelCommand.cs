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

namespace Application.Features.Personnels.Commands.UpdatePersonnel
{
    public class UpdatePersonnelCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }

        public class UpdatePersonnelCommandHandler : IRequestHandler<UpdatePersonnelCommand, Response<int>>
        {
            private readonly IPersonnelRepositoryAsync _personnelRepository;
            private readonly IMapper _mapper;
            public UpdatePersonnelCommandHandler(IPersonnelRepositoryAsync personnelRepository, IMapper mapper)
            {
                _personnelRepository = personnelRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdatePersonnelCommand request, CancellationToken cancellationToken)
            {
                var personnel = await _personnelRepository.GetByIdAsync(request.Id);

                if (personnel == null)
                {
                    throw new ApiException($"Personnel Not Found.");
                }
                else
                {
                    personnel = _mapper.Map<Personnel>(request);
                    await _personnelRepository.UpdateAsync(personnel);
                    return new Response<int>(personnel.Id);
                }
            }
        }
    }
}
