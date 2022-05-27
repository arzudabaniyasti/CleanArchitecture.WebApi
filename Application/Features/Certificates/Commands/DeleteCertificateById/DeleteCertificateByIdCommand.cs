using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Certificates.Commands.DeleteCertificateById
{
    public class DeleteCertificateByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCertificateByIdCommandHandler : IRequestHandler<DeleteCertificateByIdCommand, Response<int>>
        {
            private readonly ICertificateRepositoryAsync _certificateRepository;
            public DeleteCertificateByIdCommandHandler(ICertificateRepositoryAsync certificateRepository)
            {
                _certificateRepository = certificateRepository;
            }
            public async Task<Response<int>> Handle(DeleteCertificateByIdCommand command, CancellationToken cancellationToken)
            {
                var certificate = await _certificateRepository.GetByIdAsync(command.Id);
                if (certificate == null) throw new ApiException($"Certificate Not Found.");
                await _certificateRepository.DeleteAsync(certificate);
                return new Response<int>(certificate.Id);
            }
        }
    }
}
