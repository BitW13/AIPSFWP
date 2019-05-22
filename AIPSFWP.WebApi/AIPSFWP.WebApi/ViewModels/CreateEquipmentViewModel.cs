﻿using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.WebApi.ViewModels
{
    public class CreateEquipmentViewModel
    {
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
