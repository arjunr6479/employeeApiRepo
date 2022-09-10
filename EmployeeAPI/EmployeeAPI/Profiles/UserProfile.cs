using AutoMapper;
using EmployeeAPI.Model.Domain;
using EmployeeAPI.Model.Dto;

namespace EmployeeAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}
