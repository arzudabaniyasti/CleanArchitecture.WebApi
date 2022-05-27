using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.Personnels.Commands.AddEducationToPersonnel
{
    public partial class AddEducationToPersonnelCommand : IRequest<Response<int>>
    {
        public int PersonnelId { get; set; }
        public int EducationId { get; set; }
    }
    public class AddEducationToPersonnelCommandHandler : IRequestHandler<AddEducationToPersonnelCommand, Response<int>>
    {
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly IEducationRepositoryAsync _educationRepository;
        private readonly IMapper _mapper;

        public AddEducationToPersonnelCommandHandler(IPersonnelRepositoryAsync personnelRepository, IEducationRepositoryAsync educationRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddEducationToPersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.GetByIdAsync(request.PersonnelId);
            if (personnel == null) return null;

            var education = await _educationRepository.GetByIdAsync(request.EducationId);
            if (education == null) return null;

            education.PersonnelId = personnel.Id;

            await _educationRepository.UpdateAsync(education);

            return new Response<int>(personnel.Id);
        }
    }

}
