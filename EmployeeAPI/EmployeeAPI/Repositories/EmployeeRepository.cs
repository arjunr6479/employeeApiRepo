using EmployeeAPI.Data;
using EmployeeAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var emp = await employeeDbContext.Employees.FirstOrDefaultAsync(x=>x.EmpId==id);
            if (emp == null)
            {
                return null;
            }
            else
            {
                employeeDbContext.Remove(emp);
                await employeeDbContext.SaveChangesAsync();
            }
            return emp;
           
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await employeeDbContext.Employees.FirstOrDefaultAsync(x=>x.EmpId==id);

        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(int id,Employee employee)
        {
            var emp = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            if (emp == null)
            {
                return null;
            }
            else
            {
                emp.EmpName = employee.EmpName;
                emp.Esalary = employee.Esalary;
                emp.DeptId = employee.DeptId;

                employeeDbContext.Update(emp);
                await employeeDbContext.SaveChangesAsync();
            }
            return emp;
        }
    }
}        
       