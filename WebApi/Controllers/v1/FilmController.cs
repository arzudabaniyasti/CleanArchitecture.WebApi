using Application.Features.Films.Commands.CreateFilm;
using Application.Features.Films.Queries.GetAllFilms;
using Application.Features.Films.Queries.GetFilmById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{ 
    [ApiVersion("1.0")]
    public class FilmController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFilmsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllFilmsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFilmByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
            //        [Authorize]
            public async Task<IActionResult> Post(CreateFilmCommand command)
            {
                return Ok(await Mediator.Send(command));
            }
    }
}
