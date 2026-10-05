using MediatR;
using Microsoft.AspNetCore.Mvc;
using SameApi.Business.comment.Command;
using SameApi.Business.Post.Command;
using SameApi.Business.User.Command;

namespace SameApi.App.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("get/{id}")]
        //public async Task<ActionResult<PostResponse?>> GetPostByIdAsync(int id)
        //{
        //    var result = await _mediator.Send(new GetPostByIdQuery { Id = id });

        //    return Ok(result);
        //}

        //[HttpGet("getallbyuser/{userId}")]
        //public async Task<ActionResult<PostResponse?>> GetAllPostByUserIdAsync(int userId)
        //{
        //    var result = await _mediator.Send(new GetAllPostByIdUserQuery { UserId = userId });

        //    return Ok(result);
        //}

        [HttpPost("create")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] UpdateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            await _mediator.Send(new DeleteCommentCommand { Id = id });
            return Ok();
        }

        [HttpPost("addALike/{id}")]
        public async Task<IActionResult> AddALikeAsync(int id)
        {
            await _mediator.Send(new AddALikeCommentCommand { TargetId = id });
            return Ok();
        }
    }
}