using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class CreateWorkTaskViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int WorkObjectId { get; set; }

        [Required]
        public int? EmployeeId { get; set; }
    }
}
