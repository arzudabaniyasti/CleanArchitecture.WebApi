using Application.Features.Announcements.Commands.CreateAnnouncement;
using Application.Features.Announcements.Commands.DeleteAnnouncementById;
using Application.Features.Announcements.Commands.UpdateAnnouncement;
using Application.Features.Announcements.Queries.GetAllAnnouncements;
using Application.Features.Announcements.Queries.GetAnnouncementById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AnnouncementController : BaseApiController
    {
        // GET : api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAnnouncementsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllAnnouncementsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAnnouncementByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateAnnouncementCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateAnnouncementCommand command)
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
            return Ok(await Mediator.Send(new DeleteAnnouncementByIdCommand { Id = id }));
        }
    }
}
