using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Events.Commands.AddAddressToEvent;
using Application.Features.Events.Commands.AddParticipantToEvent;
using Application.Features.Events.Commands.CreateEvent;
using Application.Features.Events.Commands.DeleteEventById;
using Application.Features.Events.Commands.UpdateEvent;
using Application.Features.Events.Queries.GetAllEvents;
using Application.Features.Events.Queries.GetEventById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EventController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllEventsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllEventsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEventByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("AddAddressToEvent")]
        //        [Authorize]
        public async Task<IActionResult> AddAddressToEvent(AddAddressToEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost("AddParticipantToEvent")]
        //        [Authorize]
        public async Task<IActionResult> AddParticipantToEvent(AddParticipantToEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateEventCommand command)
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
            return Ok(await Mediator.Send(new DeleteEventByIdCommand { Id = id }));
        }
    }
}
