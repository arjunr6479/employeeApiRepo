using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Model.Domain
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]

        public double Esalary { get; set; }
        [Required]
        public int DeptId  { get; set; }
        public Dept Dept { get; set; }
    }
}
