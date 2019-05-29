using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIPSFWP.WebApi.Controllers.Equipments
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationModeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public OperationModeController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OperationModeViewModel>> Get()
        {
            var operationModes = await db.OperationModes.GetAllAsync();

            List<OperationModeViewModel> models = mapper.Map<List<OperationModeViewModel>>(operationModes);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            OperationMode operationMode = await db.OperationModes.GetItemByIdAsync(id);

            if (operationMode == null)
            {
                return NotFound();
            }

            OperationModeViewModel model = mapper.Map<OperationModeViewModel>(operationMode);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OperationModeViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (model.Id != null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            OperationMode operationMode = await db.OperationModes.CreateAsync(mapper.Map<OperationMode>(model));

            OperationModeViewModel newModel = mapper.Map<OperationModeViewModel>(operationMode);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]OperationModeViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            await db.OperationModes.UpdateAsync(mapper.Map<OperationMode>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            OperationMode operationMode = await db.OperationModes.GetItemByIdAsync(id);

            if (operationMode == null)
            {
                return BadRequest();
            }

            await db.OperationModes.DeleteAsync(operationMode.Id);

            OperationModeViewModel model = mapper.Map<OperationModeViewModel>(operationMode);

            return Ok(model);
        }
    }
}