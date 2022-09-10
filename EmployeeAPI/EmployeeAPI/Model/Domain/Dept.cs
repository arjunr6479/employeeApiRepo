using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Model.Domain
{
    public class Dept
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeptName { get; set; }
    }
}
