using AutoMapper;
using Tabr.Application.Common.Mappers;
using Tabr.Domain.Entities.Blog;
using Tabr.Domain.Entities.User;

namespace Tabr.Application.Entities.Posts.Queries.GetPostDetails
{
    public class PostDetailsVm : IMapWith<BlogPostEntity>
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogPostEntity, PostDetailsVm>()
                .ForMember(postVm => postVm.Details,
                    opt => opt.MapFrom(post => post.Details))
                .ForMember(postVm => postVm.Title,
                    opt => opt.MapFrom(post => post.Title))
                .ForMember(postVm => postVm.Text,
                    opt => opt.MapFrom(post => post.Text))
                .ForMember(postVm => postVm.CreatingDate,
                    opt => opt.MapFrom(post => post.CreatingDate))
                .ForMember(postVm => postVm.EditDate,
                    opt => opt.MapFrom(post => post.EditDate));
        }
    }
}