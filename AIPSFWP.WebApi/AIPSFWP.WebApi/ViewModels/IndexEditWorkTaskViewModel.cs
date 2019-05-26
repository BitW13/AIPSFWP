using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class IndexEditWorkTaskViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int WorkObjectId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
