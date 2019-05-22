using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIPSFWP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;
        
        public EmployeeController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexEditEmployeeViewModel>> Get()
        {
            var employees =  await db.Employees.GetAllAsync();

            List<IndexEditEmployeeViewModel> models = new List<IndexEditEmployeeViewModel>();

            foreach(var employee in employees)
            {
                var employeeData = await db.EmployeesDatas.GetItemByIdAsync(employee.EmployeeDataId);

                models.Add(new IndexEditEmployeeViewModel
                {
                    Id = employee.Id,
                    EmployeeDataId = employeeData.Id,
                    FirstName = employeeData.FirstName,
                    MiddleName = employeeData.MiddleName,
                    LastName = employeeData.LastName,
                    Login = employee.Login,
                    Password = employee.Password,
                    Role = employee.Role,
                    WorkObjectId = employee.WorkObjectId
                });
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await db.Employees.GetItemByIdAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            var employeeData = await db.EmployeesDatas.GetItemByIdAsync(employee.EmployeeDataId);

            if(employeeData == null)
            {
                return NotFound();
            }

            var model = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            if(model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            EmployeeData newEmployeeData = mapper.Map<EmployeeData>(model);

            var employeeData = await db.EmployeesDatas.CreateAsync(newEmployeeData);

            Employee newEmployee = mapper.Map<Employee>(model);

            newEmployee.EmployeeDataId = employeeData.Id;

            var employee = await db.Employees.CreateAsync(newEmployee);

            var newModel = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IndexEditEmployeeViewModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            Employee employee = mapper.Map<Employee>(model);
            EmployeeData employeeData = mapper.Map<EmployeeData>(model);

            employeeData.Id = employee.EmployeeDataId;

            await db.Employees.UpdateAsync(employee);
            await db.EmployeesDatas.UpdateAsync(employeeData);

            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await db.Employees.GetItemByIdAsync(id);

            if(employee == null)
            {
                return BadRequest();
            }

            EmployeeData employeeData = await db.EmployeesDatas.DeleteAsync(employee.EmployeeDataId);

            if(employeeData == null)
            {
                return BadRequest();
            }

            var model = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            if(model == null)
            {
                return BadRequest();
            }

            return Ok(model);
        }


        private IndexEditEmployeeViewModel ConvertEmployeeAndEmployeeDataToIndexViewModel(Employee employee, EmployeeData employeeData)
        {

            if(employee == null || employeeData == null)
            {
                return null;
            }

            IndexEditEmployeeViewModel model = new IndexEditEmployeeViewModel
            {
                Id = employee.Id,
                EmployeeDataId = employeeData.Id,
                FirstName = employeeData.FirstName,
                MiddleName = employeeData.MiddleName,
                LastName = employeeData.LastName,
                Login = employee.Login,
                Password = employee.Password,
                Role = employee.Role,
                WorkObjectId = employee.WorkObjectId
            };

            return model;
        }
    }
}