using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using Tabr.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tabr.Application.Entities.Posts.Queries.GetPostList
{
    public class GetPostListQueryHandler 
        : IRequestHandler<GetPostListQuery, PostListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IApplicationDbContext context, 
            IMapper mapper) => 
            (_context, _mapper) = (context, mapper);

        public async Task<PostListVm> Handle(GetPostListQuery request,
            CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .Where(post => post.UserId == request.UserId)
                .ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PostListVm { Posts = post };
        }
    }
}