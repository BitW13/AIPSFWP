namespace AIPSFWP.WebApi.ViewModels
{
    public class CreateWorkTaskViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int WorkObjectId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
