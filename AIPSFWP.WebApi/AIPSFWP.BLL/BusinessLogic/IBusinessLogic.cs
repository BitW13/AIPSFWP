﻿using AIPSFWP.BLL.Services.Interfaces;
using AIPSFWP.BLL.Services.Interfaces.Employees;
using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.BLL.Services.Interfaces.WorkObjects;
using AIPSFWP.BLL.Services.Interfaces.WorkTasks;

namespace AIPSFWP.BLL.BusinessLogic
{
    public interface IBusinessLogic
    {
        ICompanyService Companies { get; set; }

        IEmployeeService Employees { get; set; }

        IEmployeeDataService EmployeesDatas { get; set; }

        IEquipmentService Equipments { get; set; }

        IWorkObjectService WorkObjects { get; set; }

        IWorkTaskService WorkTasks { get; set; }

        IManufacturerService Manufacturers { get; set; }

        IOperationModeService OperationModes { get; set; }
    }
}
