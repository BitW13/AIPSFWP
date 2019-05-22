using System;
using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities.Employees
{
    public class EmployeeData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public byte[] Document { get; set; }

        public byte[] Photo { get; set; }

        public DateTime EndDate { get; set; }
    }
}
