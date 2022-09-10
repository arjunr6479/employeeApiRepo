using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Model.Domain
{
    public class User
    {
        [Key]
        public string  username { get; set; }
        public string password { get; set; }
    }
}
