using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AIPSFWP.Common.Entities.Equipments
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int EquipmentDataId { get; set; }
    }
}
