using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIPSFWP.Common.Entities.Equipments
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
