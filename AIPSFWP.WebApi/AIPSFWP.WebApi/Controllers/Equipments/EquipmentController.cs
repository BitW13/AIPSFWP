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
    public class EquipmentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public EquipmentController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipmentViewModel>> Get()
        {
            var equipments = await db.Equipments.GetAllAsync();

            List<EquipmentViewModel> models = mapper.Map<List<EquipmentViewModel>>(equipments);
            
            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Equipment equipment = await db.Equipments.GetItemByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            EquipmentViewModel model = mapper.Map<EquipmentViewModel>(equipment);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EquipmentViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if(model.Id != null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            Equipment equipment = await db.Equipments.CreateAsync(mapper.Map<Equipment>(model));

            EquipmentViewModel newModel = mapper.Map<EquipmentViewModel>(equipment);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]IndexEditEmployeeViewModel model)
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

            await db.Equipments.UpdateAsync(mapper.Map<Equipment>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            Equipment equipment = await db.Equipments.GetItemByIdAsync(id);

            if (equipment == null)
            {
                return BadRequest();
            }

            await db.WorkTasks.DeleteAsync(equipment.Id);

            EquipmentViewModel model = mapper.Map<EquipmentViewModel>(equipment);

            return Ok(model);
        }
    }
}