using AutoMapper;
using Tabr.Application.Common.Mappers;
using Tabr.Application.Entities.Posts.Commands.UpdatePost;

namespace Tabr.WebApi.Models
{
    public class UpdatePostDto : IMapWith<UpdatePostCommand>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePostDto, UpdatePostCommand>()
                .ForMember(command => command.Id,
                    opt => opt.MapFrom(post => post.Id))
                .ForMember(command => command.UserId,
                    opt => opt.MapFrom(post => post.UserId))
                .ForMember(command => command.Title,
                    opt => opt.MapFrom(post => post.Title))
                .ForMember(command => command.Text,
                    opt => opt.MapFrom(post => post.Text));
        }
    }
}