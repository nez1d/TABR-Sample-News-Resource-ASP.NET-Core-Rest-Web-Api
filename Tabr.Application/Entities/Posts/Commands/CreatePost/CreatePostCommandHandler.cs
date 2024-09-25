using MediatR;
using Tabr.Application.Interfaces;
using Tabr.Domain.Entities.Blog;

namespace Tabr.Application.Entities.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler 
        : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreatePostCommandHandler(IApplicationDbContext context) => 
            _context = context;

        public async Task<Guid> Handle(CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = new BlogPostEntity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                User = null,
                Details = request.Details,
                Title = request.Title,
                Text = string.Empty,
                CreatingDate = DateTime.Now,
                EditDate = null,
            };

            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}