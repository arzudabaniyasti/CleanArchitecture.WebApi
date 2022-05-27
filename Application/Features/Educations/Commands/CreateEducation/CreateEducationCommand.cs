using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Educations.Commands.CreateEducation
{
    public partial class CreateEducationCommand : IRequest<Response<int>>
    {
        public string CollegeName { get; set; }
        public string Major { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, Response<int>>
    {
        private readonly IEducationRepositoryAsync _educationRepository;
        private readonly IMapper _mapper;
        public CreateEducationCommandHandler(IEducationRepositoryAsync educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = _mapper.Map<Education>(request);
            await _educationRepository.AddAsync(education);
            return new Response<int>(education.Id);
        }
    }
}
