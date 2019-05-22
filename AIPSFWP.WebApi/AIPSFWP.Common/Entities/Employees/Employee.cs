using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities.Employees
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int EmployeeDataId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
