using AutoMapper;
using EmployeeAPI.Model.Domain;
using EmployeeAPI.Model.Dto;

namespace EmployeeAPI.Profiles
{
    public class DeptProfile:Profile
    {
        public DeptProfile()
        {
            CreateMap<Dept,DeptDto>()
            .ReverseMap();
        }
    }
}
