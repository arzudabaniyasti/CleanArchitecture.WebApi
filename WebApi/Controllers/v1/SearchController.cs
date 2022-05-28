using Application.Features.Searches.Commands.CreateSearch;
using Application.Features.Searches.Queries.GetAllSearches;
using Application.Features.Searches.Queries.GetSearchById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SearchController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSearchesParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllSearchesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSearchByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateSearchCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

