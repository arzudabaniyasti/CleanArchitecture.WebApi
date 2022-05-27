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

namespace Application.Features.Educations.Commands.UpdateEducation
{
    public class UpdateEducationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string Major { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, Response<int>>
        {
            private readonly IEducationRepositoryAsync _educationRepository;
            private readonly IMapper _mapper;
            public UpdateEducationCommandHandler(IEducationRepositoryAsync educationRepository, IMapper mapper)
            {
                _educationRepository = educationRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
            {
                var education = await _educationRepository.GetByIdAsync(request.Id);

                if (education == null)
                {
                    throw new ApiException($"Educate Not Found.");
                }
                else
                {
                    education = _mapper.Map<Education>(request);

                    //certificate.Name = command.Name;
                    //certificate.Provider = command.Provider;
                    //certificate.StartDate = command.StartDate;
                    //certificate.EndDate = command.EndDate;
                    //certificate.PersonId = command.PersonId;
                    await _educationRepository.UpdateAsync(education);
                    return new Response<int>(education.Id);
                }
            }
        }
    }
}
