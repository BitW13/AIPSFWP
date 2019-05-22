using AIPSFWP.DAL.Repositories.Interfaces;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;

namespace AIPSFWP.DAL.DataAccess
{
    public interface IDataAccess
    {
        ICompanyRepository Companies { get; set; }

        IAdminRepository Admins { get; set; }

        IEmployeeRepository Employees { get; set; }

        IEmployeeDataRepository EmployeesDatas { get; set; }

        IEquipmentRepository Equipments { get; set; }

        IEquipmentDataRepository EquipmentsDatas { get; set; }

        IWorkObjectRepository WorkObjects { get; set; }

        IWorkTaskRepository WorkTasks { get; set; }
    }
}
