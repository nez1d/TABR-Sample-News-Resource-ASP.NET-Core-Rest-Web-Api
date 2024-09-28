using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tabr.Application.Entities.Posts.Commands.CreatePost;
using Tabr.Application.Entities.Posts.Commands.DeletePost;
using Tabr.Application.Entities.Posts.Commands.UpdatePost;
using Tabr.Application.Entities.Posts.Queries.GetPostDetails;
using Tabr.Application.Entities.Posts.Queries.GetPostList;
using Tabr.WebApi.Models;

namespace Tabr.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;
        public PostController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PostListVm>> GetAll()
        {
            var query = new GetPostListQuery()
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDetailsVm>> Get(Guid id)
        {
            var query = new GetPostDetailsQuery()
            {
                UserId = UserId,
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostDto createPostDto)
        {
            var command = _mapper.Map<CreatePostCommand>(createPostDto);
            command.UserId = UserId;
            var postId = await Mediator.Send(command);
            return Ok(postId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePostDto updatePostDto)
        {
            var command = _mapper.Map<UpdatePostCommand>(updatePostDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePostCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
