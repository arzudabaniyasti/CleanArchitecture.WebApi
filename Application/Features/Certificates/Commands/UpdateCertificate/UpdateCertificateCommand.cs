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

namespace Application.Features.Certificates.Commands.UpdateCertificate
{
    public class UpdateCertificateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, Response<int>>
        {
            private readonly ICertificateRepositoryAsync _certificateRepository;
            private readonly IMapper _mapper;
            public UpdateCertificateCommandHandler(ICertificateRepositoryAsync certificateRepository, IMapper mapper)
            {
                _certificateRepository = certificateRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
            {
                var certificate = await _certificateRepository.GetByIdAsync(request.Id);

                if (certificate == null)
                {
                    throw new ApiException($"Certificate Not Found.");
                }
                else
                {
                    certificate = _mapper.Map<Certificate>(request);
                    await _certificateRepository.UpdateAsync(certificate);
                    return new Response<int>(certificate.Id);
                }
            }
        }
    }
}
