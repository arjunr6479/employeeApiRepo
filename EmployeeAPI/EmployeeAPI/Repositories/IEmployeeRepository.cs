using EmployeeAPI.Model.Domain;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        //GetEmployee
        Task <IEnumerable<Employee>> GetEmployeesAsync();

        Task <Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> DeleteEmployee(int id);
        Task <Employee> AddEmployeeAsync(Employee employee);
        Task <Employee> UpdateEmployeeAsync(int id,Employee employee);

    }
}
