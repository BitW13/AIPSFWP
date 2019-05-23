using AIPSFWP.Common.Entities.Employees;
<<<<<<< HEAD
using AIPSFWP.Common.Entities.WorkTasks;
=======
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.Common.Entities.WorkObjects;
>>>>>>> 2e116b71532b8341e84bf7fa8085287c228ee1fb
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;

namespace AIPSFWP.WebApi.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, CreateEmployeeViewModel>()
                .ReverseMap();
            CreateMap<EmployeeData, CreateEmployeeViewModel>()
                .ReverseMap();
            CreateMap<Employee, IndexEditEmployeeViewModel>()
                .ReverseMap();
            CreateMap<EmployeeData, IndexEditEmployeeViewModel>()
                .ReverseMap();
<<<<<<< HEAD
            CreateMap<WorkTask, IndexEditWorkTaskViewModel>()
                .ReverseMap();
            CreateMap<WorkTask, CreateWorkTaskViewModel>()
=======

            CreateMap<Equipment, CreateEquipmentViewModel>()
                .ReverseMap();
            CreateMap<EquipmentData, CreateEquipmentViewModel>()
                .ReverseMap();
            CreateMap<Equipment, IndexEditEquipmentViewModel>()
                .ReverseMap();
            CreateMap<EquipmentData, IndexEditEquipmentViewModel>()
                .ReverseMap();

            CreateMap<WorkObject, IndexEditWorkObjectViewModel>()
                .ReverseMap();
            CreateMap<WorkObject, CreateWorkObjectViewModel>()
>>>>>>> 2e116b71532b8341e84bf7fa8085287c228ee1fb
                .ReverseMap();
        }
    }
}
