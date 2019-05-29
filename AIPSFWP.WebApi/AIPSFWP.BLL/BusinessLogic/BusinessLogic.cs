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
                             IEmployeeService employees,
                             IEmployeeDataService employeesDatas,
                             IEquipmentService equipments,
                             IWorkObjectService workObjects,
                             IWorkTaskService workTasks,
                             IManufacturerService manufacturers,
                             IOperationModeService operationModes)
        {
            Companies = companies;
            Employees = employees;
            EmployeesDatas = employeesDatas;
            Equipments = equipments;
            WorkObjects = workObjects;
            WorkTasks = workTasks;
            Manufacturers = manufacturers;
            OperationModes = operationModes;
        }

        public ICompanyService Companies { get; set; }

        public IEmployeeService Employees { get; set; }

        public IEmployeeDataService EmployeesDatas { get; set; }

        public IEquipmentService Equipments { get; set; }

        public IWorkObjectService WorkObjects { get; set; }

        public IWorkTaskService WorkTasks { get; set; }
        public IManufacturerService Manufacturers { get; set; }
        public IOperationModeService OperationModes { get; set; }
    }
}
