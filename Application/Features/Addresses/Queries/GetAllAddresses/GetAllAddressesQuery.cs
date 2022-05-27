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

namespace Application.Features.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesQuery : IRequest<PagedResponse<IEnumerable<GetAllAddressesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, PagedResponse<IEnumerable<GetAllAddressesViewModel>>>
    {
        private readonly IAddressRepositoryAsync _addressRepository;
        private readonly IMapper _mapper;
        public GetAllAddressesQueryHandler(IAddressRepositoryAsync addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllAddressesViewModel>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllAddressesParameter>(request);
            var address = await _addressRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var addressViewModel = _mapper.Map<IEnumerable<GetAllAddressesViewModel>>(address);
            return new PagedResponse<IEnumerable<GetAllAddressesViewModel>>(addressViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
