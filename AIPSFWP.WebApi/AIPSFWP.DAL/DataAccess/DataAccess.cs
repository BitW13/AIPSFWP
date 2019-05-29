using AIPSFWP.DAL.Repositories.Interfaces;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;

namespace AIPSFWP.DAL.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ICompanyRepository companies,
                          IEmployeeRepository employees,
                          IEmployeeDataRepository employeesDatas,
                          IEquipmentRepository equipments,
                          IWorkObjectRepository workObjects,
                          IWorkTaskRepository workTasks,
                          IManufacturerRepository manufacturers,
                          IOperationModeRepository operationModes)
        {
            Companies = companies;
            Employees = employees;
            EmployeesDatas = employeesDatas;
            Equipments = equipments;
            WorkObjects = workObjects;
            WorkTasks = workTasks;
            OperationModes = operationModes;
            Manufacturers = manufacturers;
        }

        public ICompanyRepository Companies { get; set; }

        public IEmployeeRepository Employees { get; set; }

        public IEmployeeDataRepository EmployeesDatas { get; set; }

        public IEquipmentRepository Equipments { get; set; }

        public IWorkObjectRepository WorkObjects { get; set; }

        public IWorkTaskRepository WorkTasks { get; set; }
        public IOperationModeRepository OperationModes { get; set; }
        public IManufacturerRepository Manufacturers { get; set; }
    }
}
