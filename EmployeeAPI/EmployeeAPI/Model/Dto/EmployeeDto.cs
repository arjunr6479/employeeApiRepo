using EmployeeAPI.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Model.Dto
{
    public class EmployeeDto
    {
        
        public int EmpId { get; set; }
        
        public string EmpName { get; set; }
        

        public double Esalary { get; set; }
        
        public int DeptId { get; set; }
        public Dept Dept { get; set; }
    }
}
