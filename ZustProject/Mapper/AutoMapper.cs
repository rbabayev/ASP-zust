using AutoMapper;
using Zust.Entities.Entities;
using ZustProject.Dtos;

namespace ZustProject.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
