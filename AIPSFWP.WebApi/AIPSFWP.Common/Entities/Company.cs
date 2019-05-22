using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.Common.Entities.WorkObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public virtual List<WorkObject> WorkObjects { get; set; }

        public virtual List<Equipment> Equipments { get; set; }
    }
}
