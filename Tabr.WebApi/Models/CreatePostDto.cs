using AutoMapper;
using Tabr.Application.Common.Mappers;
using Tabr.Application.Entities.Posts.Commands.CreatePost;

namespace Tabr.WebApi.Models
{
    public class CreatePostDto : IMapWith<CreatePostCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, CreatePostCommand>()
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(post => post.Title))
                .ForMember(command => command.Details,
                    opt => opt.MapFrom(post => post.Title));
        }
    }
}