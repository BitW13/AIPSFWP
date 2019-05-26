using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class IndexEditEmployeeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployeeDataId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public int? WorkObjectId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
