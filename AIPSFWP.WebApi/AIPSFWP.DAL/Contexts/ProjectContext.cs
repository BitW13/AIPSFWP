using AIPSFWP.Common.Entities;
using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.Common.Entities.WorkObjects;
using AIPSFWP.Common.Entities.WorkTasks;
using Microsoft.EntityFrameworkCore;

namespace AIPSFWP.DAL.Contexts
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeData> EmployeesDatas { get; set; }

        public DbSet<WorkObject> WorkObjects { get; set; }

        public DbSet<WorkTask> WorkTasks { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<OperationMode> OperationModes { get; set; }
    }
}
