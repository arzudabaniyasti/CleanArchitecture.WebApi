using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Certificates.Commands.CreateCertificate;
using Application.Features.Certificates.Commands.DeleteCertificateById;
using Application.Features.Certificates.Commands.UpdateCertificate;
using Application.Features.Certificates.Queries.GetAllCertificates;
using Application.Features.Certificates.Queries.GetCertificateById;
using Application.Features.Personnels.Commands.AddAddressToPersonnel;
using Application.Features.Personnels.Commands.AddCertificateToPersonnel;
using Application.Features.Personnels.Commands.AddEducationToPersonnel;
using Application.Features.Personnels.Commands.CreatePersonnel;
using Application.Features.Personnels.Commands.DeletePersonnelById;
using Application.Features.Personnels.Commands.UpdatePersonnel;
using Application.Features.Personnels.Queries.GetAllPersonnels;
using Application.Features.Personnels.Queries.GetPersonnelById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonnelController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonnelsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllPersonnelsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPersonnelByIdQuery { Id = id }));//getpersonel by id query tipindeki talebi karşılayacak servisi bulup talebi ona iletiyor.(mediator)
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreatePersonnelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("AddEducationToPersonnel")]
        //        [Authorize]
        public async Task<IActionResult> AddEducationToPersonnel(AddEducationToPersonnelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("AddAddressToPersonnel")]
        //        [Authorize]
        public async Task<IActionResult> AddAddressToPersonnel(AddAddressToPersonnelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("AddCertificateToPersonnel")]
        //        [Authorize]
        public async Task<IActionResult> AddCertificateToPersonnel(AddCertificateToPersonnelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonnelCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //       [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonnelByIdCommand { Id = id }));
        }

        // POST api/<controller>
        [HttpPost("MyNew")]
        //        [Authorize]
        public async Task<IActionResult> AddAddressToPersonnel2(AddAddressToPersonnelCommand command,int a,int b)
        {
            int result = a + b;
            return Ok("your var is "+ (result));
        }

    }
}
