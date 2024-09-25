using MediatR;

namespace Tabr.Application.Entities.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
