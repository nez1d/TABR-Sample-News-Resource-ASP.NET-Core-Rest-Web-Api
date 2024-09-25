using MediatR;

namespace Tabr.Application.Entities.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
    }
}