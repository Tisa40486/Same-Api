using MediatR;
using Microsoft.AspNetCore.Mvc;
using SameApi.Business.Post.Command;
using SameApi.Business.Post.Query;
using SameApi.Business.User.Command;
using SameApi.Dto;

namespace SameApi.App.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<PostResponse?>> GetPostByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpGet("getallbyuser/{userId}")]
        public async Task<ActionResult<PostResponse?>> GetAllPostByUserIdAsync(int userId)
        {
            var result = await _mediator.Send(new GetAllCommentByIdPostQuery { UserId = userId });

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePostAsync([FromBody] UpdatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            await _mediator.Send(new DeletePostCommand { Id = id });
            return Ok();
        }
        [HttpPost("addALike/{id}")]
        public async Task<IActionResult> AddALikeAsync(int id)
        {
            await _mediator.Send(new AddALikePostCommand { TargetId = id });
            return Ok();
        }
    }
}