using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIPSFWP.WebApi.ViewModels
{
    public class IndexEditWorkTaskViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int WorkObjectId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
