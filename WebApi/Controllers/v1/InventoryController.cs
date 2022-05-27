using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Inventories.Commands.CreateInventory;
using Application.Features.Inventories.Commands.DeleteInventoryById;
using Application.Features.Inventories.Commands.UpdateInventory;
using Application.Features.Inventories.Queries.GetAllInventories;
using Application.Features.Inventories.Queries.GetInventoryById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InventoryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllInventoriesParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllInventoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetInventoryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateInventoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        // POST api/<controller>
        [HttpPost("AddProductToInventory")]
        //        [Authorize]
        public async Task<IActionResult> AddProductToInventory(AddProductToInventoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateInventoryCommand command)
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
            return Ok(await Mediator.Send(new DeleteInventoryByIdCommand { Id = id }));
        }
    }
}
