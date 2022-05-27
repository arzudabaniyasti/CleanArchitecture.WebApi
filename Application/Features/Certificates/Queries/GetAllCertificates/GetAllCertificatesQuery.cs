using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Certificates.Queries.GetAllCertificates
{
    public class GetAllCertificatesQuery : IRequest<PagedResponse<IEnumerable<GetAllCertificatesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCertificatesQueryHandler : IRequestHandler<GetAllCertificatesQuery, PagedResponse<IEnumerable<GetAllCertificatesViewModel>>>
    {
        private readonly ICertificateRepositoryAsync _certificateRepository;
        private readonly IMapper _mapper;
        public GetAllCertificatesQueryHandler(ICertificateRepositoryAsync certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCertificatesViewModel>>> Handle(GetAllCertificatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCertificatesParameter>(request);
            var certificate = await _certificateRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var certificateViewModel = _mapper.Map<IEnumerable<GetAllCertificatesViewModel>>(certificate);
            return new PagedResponse<IEnumerable<GetAllCertificatesViewModel>>(certificateViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
