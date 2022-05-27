using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Certificates.Commands.CreateCertificate
{
    public partial class CreateCertificateCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, Response<int>>
    {
        private readonly ICertificateRepositoryAsync _certificateRepository;
        private readonly IMapper _mapper;
        public CreateCertificateCommandHandler(ICertificateRepositoryAsync certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = _mapper.Map<Certificate>(request);
            await _certificateRepository.AddAsync(certificate);
            return new Response<int>(certificate.Id);
        }
    }
}
