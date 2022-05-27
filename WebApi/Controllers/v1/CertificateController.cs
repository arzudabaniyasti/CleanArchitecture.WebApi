using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Certificates.Commands.CreateCertificate;
using Application.Features.Certificates.Commands.DeleteCertificateById;
using Application.Features.Certificates.Commands.UpdateCertificate;
using Application.Features.Certificates.Queries.GetAllCertificates;
using Application.Features.Certificates.Queries.GetCertificateById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CertificateController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCertificatesParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllCertificatesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCertificateByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
//        [Authorize]
        public async Task<IActionResult> Post(CreateCertificateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateCertificateCommand command)
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
            return Ok(await Mediator.Send(new DeleteCertificateByIdCommand { Id = id }));
        }
    }
}
