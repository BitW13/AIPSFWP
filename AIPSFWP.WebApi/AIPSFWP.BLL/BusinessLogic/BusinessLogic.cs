using AIPSFWP.BLL.Services.Interfaces;
using AIPSFWP.BLL.Services.Interfaces.Employees;
using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.BLL.Services.Interfaces.WorkObjects;
using AIPSFWP.BLL.Services.Interfaces.WorkTasks;

namespace AIPSFWP.BLL.BusinessLogic
{
    public class BusinessLogic : IBusinessLogic
    {
        public BusinessLogic(ICompanyService companies,
                             IAdminService admins,
                             IEmployeeService employees,
                             IEmployeeDataService employeesDatas,
                             IEquipmentService equipments,
                             IEquipmentDataService equipmentsDatas,
                             IWorkObjectService workObjects,
                             IWorkTaskService workTasks)
        {
            Companies = companies;
            Admins = admins;
            Employees = employees;
            EmployeesDatas = employeesDatas;
            Equipments = equipments;
            EquipmentsDatas = equipmentsDatas;
            WorkObjects = workObjects;
            WorkTasks = workTasks;
        }

        public ICompanyService Companies { get; set; }

        public IAdminService Admins { get; set; }

        public IEmployeeService Employees { get; set; }

        public IEmployeeDataService EmployeesDatas { get; set; }

        public IEquipmentService Equipments { get; set; }

        public IEquipmentDataService EquipmentsDatas { get; set; }

        public IWorkObjectService WorkObjects { get; set; }

        public IWorkTaskService WorkTasks { get; set; }
    }
}
