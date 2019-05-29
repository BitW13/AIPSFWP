using System;
using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class EquipmentViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        [Required]
        public string InventoryNumber { get; set; }

        [Required]
        public DateTime ManufactureDate { get; set; }

        [Required]
        public DateTime CertificationDate { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public int OperationModeId { get; set; }

        public int? WorkObjectId { get; set; }
    }
}
