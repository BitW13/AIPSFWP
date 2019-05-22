using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class IndexEditEquipmentViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int EquipmentDataId { get; set; }

        public int? WorkObjectId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
