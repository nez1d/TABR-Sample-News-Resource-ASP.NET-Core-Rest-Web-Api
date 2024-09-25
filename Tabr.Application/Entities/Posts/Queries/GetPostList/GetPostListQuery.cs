using MediatR;

namespace Tabr.Application.Entities.Posts.Queries.GetPostList
{
    public class GetPostListQuery : IRequest<PostListVm>
    {
        public Guid UserId { get; set; }
    }
}