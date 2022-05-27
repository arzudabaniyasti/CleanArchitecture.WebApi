using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Personnels.Commands.AddCertificateToPersonnel
{
    public partial class AddCertificateToPersonnelCommand : IRequest<Response<int>>
    {
        public int PersonnelId { get; set; }
        public int CertificateId { get; set; }
    }
    public class AddCertificateToPersonnelCommandHandler : IRequestHandler<AddCertificateToPersonnelCommand, Response<int>>
    {
        private readonly IPersonnelRepositoryAsync _personnelRepository;
        private readonly ICertificateRepositoryAsync _certificateRepository;
        private readonly IMapper _mapper;

        public AddCertificateToPersonnelCommandHandler(IPersonnelRepositoryAsync personnelRepository, ICertificateRepositoryAsync certificateRepository, IMapper mapper)
        {
            _personnelRepository = personnelRepository;
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddCertificateToPersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.GetByIdAsync(request.PersonnelId);
            if (personnel == null) return null;

            var certificate = await _certificateRepository.GetByIdAsync(request.CertificateId);
            if (certificate == null) return null;

            certificate.PersonnelId = personnel.Id;

            await _certificateRepository.UpdateAsync(certificate);

            return new Response<int>(personnel.Id);
        }

    }
}
