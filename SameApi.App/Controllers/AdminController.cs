using MediatR;
using Microsoft.AspNetCore.Mvc;
using SameApi.Business.Admin.Command;
using SameApi.Business.Admin.Query;
using SameApi.Dto;

namespace SameApi.App.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gender")]
        public async Task<ActionResult<IEnumerable<GenderResponse>>> GetAllGenderAsync()
        {
            var result = await _mediator.Send(new GetAllGenderQuery());
            return Ok(result);
        }


        [HttpPost("profession")]
        public async Task CreateProfessionAsync([FromBody] CreateProfessionCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("profession")]
        public async Task<ActionResult<IEnumerable<ProfessionResponse>>> GetAllProfessionAsync()
        {
            var result = await _mediator.Send(new GetAllProfessionQuery());
            return Ok(result);
        }

        [HttpPost("school")]
        public async Task CreateSchoolAsync([FromBody] CreateSchoolCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("school")]
        public async Task<ActionResult<IEnumerable<SchoolResponse>>> GetAllSchoolAsync()
        {
            var result = await _mediator.Send(new GetAllSchoolQuery());
            return Ok(result);
        }
    }
}