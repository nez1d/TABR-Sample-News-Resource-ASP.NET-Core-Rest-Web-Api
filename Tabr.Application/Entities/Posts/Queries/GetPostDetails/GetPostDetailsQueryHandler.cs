using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tabr.Application.Interfaces;
using Tabr.Application.Common.Exceptions;
using Tabr.Domain.Entities.Blog;

namespace Tabr.Application.Entities.Posts.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler 
        : IRequestHandler<GetPostDetailsQuery, PostDetailsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostDetailsQueryHandler(IApplicationDbContext context,
            IMapper mapper) => (_context, _mapper) = (context, mapper);
            

        public async Task<PostDetailsVm> Handle(GetPostDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(note => 
                note.Id == request.Id, cancellationToken);

            if(post == null || post.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(BlogPostEntity), request.Id);
            }

            return _mapper.Map<PostDetailsVm>(post);
        }
    }
}
