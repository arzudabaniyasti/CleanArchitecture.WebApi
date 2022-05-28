using Application.Features.WatchedLists.Commands.CreateWatchedList;
using Application.Features.WatchedLists.Queries.GetAllWatchedLists;
using Application.Features.WatchedLists.Queries.GetWatchedListById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WatchedListController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllWatchedListsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllWatchedListsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWatchedListByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateWatchedListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
