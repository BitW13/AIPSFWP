using AIPSFWP.Common.Entities.WorkTasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AIPSFWP.Common.Entities.WorkObjects
{
    public class WorkObject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<WorkTask> WorkTasks { get; set; }
    }
}
