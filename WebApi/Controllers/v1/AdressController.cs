using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Commands.DeleteAddressById;
using Application.Features.Addresses.Commands.UpdateAddress;
using Application.Features.Addresses.Queries.GetAllAddresses;
using Application.Features.Addresses.Queries.GetAddressById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AddressController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAddressesParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllAddressesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAddressByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateAddressCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateAddressCommand command)
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
            return Ok(await Mediator.Send(new DeleteAddressByIdCommand { Id = id }));
        }
    }
}
