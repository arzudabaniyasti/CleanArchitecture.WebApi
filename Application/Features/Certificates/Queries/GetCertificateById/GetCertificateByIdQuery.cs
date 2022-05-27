using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Certificates.Queries.GetCertificateById
{
    public class GetCertificateByIdQuery : IRequest<Response<Certificate>>
    {
        public int Id { get; set; }
        public class GetCertificateByIdQueryHandler : IRequestHandler<GetCertificateByIdQuery, Response<Certificate>>
        {
            private readonly ICertificateRepositoryAsync _certificateRepository;
            public GetCertificateByIdQueryHandler(ICertificateRepositoryAsync certificateRepository)
            {
                _certificateRepository = certificateRepository;
            }
            public async Task<Response<Certificate>> Handle(GetCertificateByIdQuery query, CancellationToken cancellationToken)
            {
                var certificate = await _certificateRepository.GetByIdAsync(query.Id);
                if (certificate == null) throw new ApiException($"Certificate Not Found.");
                return new Response<Certificate>(certificate);
            }
        }
    }
}
