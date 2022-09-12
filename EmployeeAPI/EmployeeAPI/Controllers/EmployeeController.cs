using AutoMapper;
using EmployeeAPI.Model.Domain;
using EmployeeAPI.Model.Dto;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmpAsync()
        {
            var allEmps = await employeeRepository.GetEmployeesAsync();
            var empsDto = mapper.Map<List<EmployeeDto>>(allEmps);
            return Ok(empsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpByIdAsync(int id)
        {
            var emp = await employeeRepository.GetEmployeeByIdAsync(id);
            var empsDto = mapper.Map<EmployeeDto>(emp);
            return Ok(empsDto);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEmpAsync(int id)
        {
            var emp = await employeeRepository.DeleteEmployee(id);
            if(emp == null)
            {
                return NotFound();
            }
            var empDto = mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddEmpAsync(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var empModel = new Employee()
                {
                    EmpName = emp.EmpName,
                    Esalary = emp.Esalary,
                    DeptId = emp.DeptId,
                };
                emp=await employeeRepository.AddEmployeeAsync(empModel);
                var empDto=mapper.Map<EmployeeDto>(emp);
                return Ok(empDto);
            }
        }
        [HttpPut("empId")]
        public async Task<IActionResult> UpdateEmpAsync(int id,Employee employee)
        {
            var emp = await employeeRepository.UpdateEmployeeAsync(id, employee);
            if (emp == null)
            {
                return NotFound();
            }
            var empDto = mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);


        }

    }
    
      
}
