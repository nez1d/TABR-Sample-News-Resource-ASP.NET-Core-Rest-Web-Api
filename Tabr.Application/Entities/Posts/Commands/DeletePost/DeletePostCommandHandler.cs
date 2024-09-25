using MediatR;
using Tabr.Application.Interfaces;
using Tabr.Domain.Entities.Blog;
using Tabr.Application.Common.Exceptions;

namespace Tabr.Application.Entities.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler 
        : IRequestHandler<DeletePostCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeletePostCommandHandler(IApplicationDbContext context) =>
            _context = context;

        public async Task Handle(DeletePostCommand request, 
            CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .FindAsync(new object[] { request.Id },
                cancellationToken);

            if(post == null || post.Id != request.Id)
            {
                throw new NotFoundException(nameof(BlogPostEntity), request.Id);
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
