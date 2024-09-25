using MediatR;
using Microsoft.EntityFrameworkCore;
using Tabr.Application.Common.Exceptions;
using Tabr.Application.Interfaces;
using Tabr.Domain.Entities.Blog;

namespace Tabr.Application.Entities.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler 
        : IRequestHandler<UpdatePostCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePostCommandHandler(IApplicationDbContext context) =>
            _context = context;

        public async Task Handle(UpdatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(post => 
                post.Id == request.Id, cancellationToken);

            if(post == null || post.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(BlogPostEntity), request.Id);
            }
            post.Id = request.Id;
            post.UserId = request.UserId;
            post.Text = request.Text;
            post.Title = request.Title;
            post.EditDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
