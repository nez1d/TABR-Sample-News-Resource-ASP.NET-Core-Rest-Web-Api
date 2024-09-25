using MediatR;

namespace Tabr.Application.Entities.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<PostDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}