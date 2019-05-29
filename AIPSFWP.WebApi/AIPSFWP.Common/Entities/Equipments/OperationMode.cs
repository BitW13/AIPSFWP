using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIPSFWP.Common.Entities.Equipments
{
    public class OperationMode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double RatedCurrent { get; set; }

        [Required]
        public double MinCurrent { get; set; }

        [Required]
        public double MaxCurrent { get; set; }

        [Required]
        public double MinVoltage { get; set; }

        [Required]
        public double MaxVoltage { get; set; }

        [Required]
        public double SupplyVoltage { get; set; }

        [Required]
        public double NoLoadVoltage { get; set; }

        [Required]
        public double MaxPowerConsumption { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
