using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.BLL.Services.Implementations;
using AIPSFWP.BLL.Services.Implementations.Employees;
using AIPSFWP.BLL.Services.Implementations.Equipments;
using AIPSFWP.BLL.Services.Implementations.WorkObjects;
using AIPSFWP.BLL.Services.Implementations.WorkTasks;
using AIPSFWP.BLL.Services.Interfaces;
using AIPSFWP.BLL.Services.Interfaces.Employees;
using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.BLL.Services.Interfaces.WorkObjects;
using AIPSFWP.BLL.Services.Interfaces.WorkTasks;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.DataAccess;
using AIPSFWP.DAL.Repositories.Implementations;
using AIPSFWP.DAL.Repositories.Implementations.Employees;
using AIPSFWP.DAL.Repositories.Implementations.Equipments;
using AIPSFWP.DAL.Repositories.Implementations.WorkObjects;
using AIPSFWP.DAL.Repositories.Implementations.WorkTasks;
using AIPSFWP.DAL.Repositories.Interfaces;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIPSFWP.DI
{
    public static class IoC
    {
        public static void IoCCommonRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeDataRepository, EmployeeDataRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IEquipmentDataRepository, EquipmentDataRepository>();
            services.AddTransient<IWorkObjectRepository, WorkObjectRepository>();
            services.AddTransient<IWorkTaskRepository, WorkTaskRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IBusinessLogic, BusinessLogic>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeDataService, EmployeeDataService>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IEquipmentDataService, EquipmentDataService>();
            services.AddTransient<IWorkObjectService, WorkObjectService>();
            services.AddTransient<IWorkTaskService, WorkTaskService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<ICompanyService, CompanyService>();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
