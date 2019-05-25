using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.WorkObjects;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkObjectController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public WorkObjectController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexEditWorkObjectViewModel>> Get()
        {
            var workObjects = await db.WorkObjects.GetAllAsync();

            List<IndexEditWorkObjectViewModel> models = mapper.Map<List<IndexEditWorkObjectViewModel>>(workObjects);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var workObject = await db.WorkObjects.GetItemByIdAsync(id);

            if (workObject == null)
            {
                return NotFound();
            }

            IndexEditWorkObjectViewModel model = mapper.Map<IndexEditWorkObjectViewModel>(workObject);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkObjectViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            WorkObject workObject = mapper.Map<WorkObject>(model);

            WorkObject newWorkObject = await db.WorkObjects.CreateAsync(workObject);

            IndexEditWorkObjectViewModel newModel = mapper.Map<IndexEditWorkObjectViewModel>(newWorkObject);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IndexEditWorkObjectViewModel model)
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

            WorkObject workObject = mapper.Map<WorkObject>(model);

            await db.WorkObjects.UpdateAsync(workObject);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            WorkObject workObject = await db.WorkObjects.DeleteAsync(id);

            if (workObject == null)
            {
                return BadRequest();
            }

            IndexEditWorkObjectViewModel model = mapper.Map<IndexEditWorkObjectViewModel>(workObject);

            if (model == null)
            {
                return BadRequest();
            }

            return Ok(model);
        }
    }
}