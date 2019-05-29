using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.Common.Entities.WorkTasks;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.Common.Entities.WorkObjects;
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
            CreateMap<WorkTask, IndexEditWorkTaskViewModel>()
                .ReverseMap();
            CreateMap<WorkTask, CreateWorkTaskViewModel>()
                .ReverseMap();
            CreateMap<WorkObject, IndexEditWorkObjectViewModel>()
                .ReverseMap();
            CreateMap<WorkObject, CreateWorkObjectViewModel>()
                .ReverseMap();
        }
    }
}
