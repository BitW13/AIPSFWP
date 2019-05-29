using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("byworkobjectid/{id}")]
        public async Task<IEnumerable<IndexEditEmployeeViewModel>> GetByWorkObjectId(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            var employees = await db.Employees.GetItemsByWorkObjectIdAsync(id);

            List<IndexEditEmployeeViewModel> models = new List<IndexEditEmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeData employeeData = await db.EmployeesDatas.GetItemByIdAsync(employee.EmployeeDataId);

                models.Add(ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData));
            }

            return models;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexEditEmployeeViewModel>> Get()
        {
            var employees = await db.Employees.GetAllAsync();

            List<IndexEditEmployeeViewModel> models = new List<IndexEditEmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeData employeeData = await db.EmployeesDatas.GetItemByIdAsync(employee.EmployeeDataId);

                models.Add(ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData));
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Employee employee = await db.Employees.GetItemByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            EmployeeData employeeData = await db.EmployeesDatas.GetItemByIdAsync(employee.EmployeeDataId);

            if (employeeData == null)
            {
                return NotFound();
            }

            IndexEditEmployeeViewModel model = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            EmployeeData newEmployeeData = mapper.Map<EmployeeData>(model);

            EmployeeData employeeData = await db.EmployeesDatas.CreateAsync(newEmployeeData);

            Employee newEmployee = mapper.Map<Employee>(model);

            newEmployee.EmployeeDataId = employeeData.Id;

            Employee employee = await db.Employees.CreateAsync(newEmployee);

            IndexEditEmployeeViewModel newModel = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IndexEditEmployeeViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            if (id != model.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            Employee employee = mapper.Map<Employee>(model);
            EmployeeData employeeData = mapper.Map<EmployeeData>(model);

            employeeData.Id = employee.EmployeeDataId;

            await db.Employees.UpdateAsync(employee);
            await db.EmployeesDatas.UpdateAsync(employeeData);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await db.Employees.GetItemByIdAsync(id);

            if (employee == null)
            {
                return BadRequest();
            }

            EmployeeData employeeData = await db.EmployeesDatas.DeleteAsync(employee.EmployeeDataId);

            if (employeeData == null)
            {
                return BadRequest();
            }

            await db.Employees.DeleteAsync(employee.Id);

            IndexEditEmployeeViewModel model = ConvertEmployeeAndEmployeeDataToIndexViewModel(employee, employeeData);

            if (model == null)
            {
                return BadRequest();
            }

            return Ok(model);
        }


        private IndexEditEmployeeViewModel ConvertEmployeeAndEmployeeDataToIndexViewModel(Employee employee, EmployeeData employeeData)
        {

            if (employee == null || employeeData == null)
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