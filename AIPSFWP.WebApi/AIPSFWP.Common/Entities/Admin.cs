using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
