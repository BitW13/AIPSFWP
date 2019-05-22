using AIPSFWP.Common.Entities.Employees;
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
        }
    }
}
