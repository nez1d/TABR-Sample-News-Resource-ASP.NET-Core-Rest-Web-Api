using AutoMapper;
using Tabr.Application.Common.Mappers;
using Tabr.Domain.Entities.Blog;

namespace Tabr.Application.Entities.Posts.Queries.GetPostList
{
    public class PostLookupDto : IMapWith<BlogPostEntity>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogPostEntity, PostLookupDto>()
                .ForMember(post => post.Id,
                    opt => opt.MapFrom(post => post.Id))
                .ForMember(post => post.Id,
                    opt => opt.MapFrom(post => post.Id));
        }
    }
}