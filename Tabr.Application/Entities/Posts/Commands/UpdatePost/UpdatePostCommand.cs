using MediatR;

namespace Tabr.Application.Entities.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}