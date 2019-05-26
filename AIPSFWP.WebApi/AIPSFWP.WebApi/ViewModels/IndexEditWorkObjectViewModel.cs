using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class IndexEditWorkObjectViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
