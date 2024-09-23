using AutoMapper;

namespace Tabr.Application.Common.Mappers
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
