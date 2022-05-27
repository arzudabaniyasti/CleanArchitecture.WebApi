﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Educations.Commands.CreateEducation;
using Application.Features.Educations.Commands.DeleteEducationById;
using Application.Features.Educations.Commands.UpdateEducation;
using Application.Features.Educations.Queries.GetAllEducations;
using Application.Features.Educations.Queries.GetEducationById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EducationController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllEducationsParamater filter)
        {

            return Ok(await Mediator.Send(new GetAllEducationsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEducationByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateEducationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateEducationCommand command)
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
            return Ok(await Mediator.Send(new DeleteEducationByIdCommand { Id = id }));
        }
    }
}
