using Application.Features.Diaries.Commands.CreateDiaries;
using Application.Features.Diaries.Queries.GetAllDiaries;
using Application.Features.Diaries.Queries.GetDiaryById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DiaryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllDiariesParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllDiariesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDiaryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //        [Authorize]
        public async Task<IActionResult> Post(CreateDiaryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
