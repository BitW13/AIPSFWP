using AIPSFWP.DAL.Repositories.Interfaces;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIPSFWP.DAL.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ICompanyRepository companies,
                          IAdminRepository admins,
                          IEmployeeRepository employees,
                          IEmployeeDataRepository employeesDatas,
                          IEquipmentRepository equipments,
                          IEquipmentDataRepository equipmentsDatas,
                          IWorkObjectRepository workObjects,
                          IWorkTaskRepository workTasks)
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

        public ICompanyRepository Companies { get; set; }

        public IAdminRepository Admins { get; set; }

        public IEmployeeRepository Employees { get; set; }

        public IEmployeeDataRepository EmployeesDatas { get; set; }

        public IEquipmentRepository Equipments { get; set; }

        public IEquipmentDataRepository EquipmentsDatas { get; set; }

        public IWorkObjectRepository WorkObjects { get; set; }

        public IWorkTaskRepository WorkTasks { get; set; }
    }
}
