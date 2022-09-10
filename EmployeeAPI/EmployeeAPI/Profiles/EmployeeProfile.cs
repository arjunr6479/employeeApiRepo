using AutoMapper;
using EmployeeAPI.Model.Domain;
using EmployeeAPI.Model.Dto;

namespace EmployeeAPI.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
            .ReverseMap();
        }

    }
}
