using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities.WorkTasks
{
    public class WorkTask
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int WorkObjectId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
