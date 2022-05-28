using Application.Features.WatchLists.Commands.CreateWatchList;
using Application.Features.WatchLists.Queries.GetAllWatchLists;
using Application.Features.WatchLists.Queries.GetWatchListById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WatchListController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllWatchListsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllWatchListsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWatchListByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateWatchListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

