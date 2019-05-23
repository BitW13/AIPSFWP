using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.Common.Entities.WorkObjects;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .ReverseMap();
        }
    }
}
