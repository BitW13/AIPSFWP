using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.WebApi.Controllers
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

        [HttpGet("byworkobjectid/{id}")]
        public async Task<IEnumerable<IndexEditEquipmentViewModel>> GetByWorkObjectId(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var equipments = await db.Equipments.GetItemsByWorkObjectIdAsync(id);

            List<IndexEditEquipmentViewModel> models = new List<IndexEditEquipmentViewModel>();

            foreach (var equipment in equipments)
            {
                var equipmentData = await db.EquipmentsDatas.GetItemByIdAsync(equipment.EquipmentDataId);

                models.Add(ConvertEquipmentAndEquipmentDataToIndexViewModel(equipment, equipmentData));
            }

            return models;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexEditEquipmentViewModel>> Get()
        {
            var equipments = await db.Equipments.GetAllAsync();

            List<IndexEditEquipmentViewModel> models = new List<IndexEditEquipmentViewModel>();

            foreach (var equipment in equipments)
            {
                var equipmentData = await db.EquipmentsDatas.GetItemByIdAsync(equipment.EquipmentDataId);

                models.Add(ConvertEquipmentAndEquipmentDataToIndexViewModel(equipment, equipmentData));
            }

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var equipment = await db.Equipments.GetItemByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            var equipmentData = await db.EquipmentsDatas.GetItemByIdAsync(equipment.EquipmentDataId);

            if (equipmentData == null)
            {
                return NotFound();
            }

            var model = ConvertEquipmentAndEquipmentDataToIndexViewModel(equipment, equipmentData);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEquipmentViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            EquipmentData newEquipmentData = mapper.Map<EquipmentData>(model);

            var equipmentData = await db.EquipmentsDatas.CreateAsync(newEquipmentData);

            Equipment newEquipment = mapper.Map<Equipment>(model);

            newEquipment.EquipmentDataId = equipmentData.Id;

            var equipment = await db.Equipments.CreateAsync(newEquipment);

            var newModel = ConvertEquipmentAndEquipmentDataToIndexViewModel(equipment, equipmentData);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IndexEditEquipmentViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            Equipment equipment = mapper.Map<Equipment>(model);
            EquipmentData equipmentData = mapper.Map<EquipmentData>(model);

            equipmentData.Id = equipment.EquipmentDataId;

            await db.Equipments.UpdateAsync(equipment);
            await db.EquipmentsDatas.UpdateAsync(equipmentData);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Equipment equipment = await db.Equipments.GetItemByIdAsync(id);

            if (equipment == null)
            {
                return BadRequest();
            }

            EquipmentData equipmentData = await db.EquipmentsDatas.DeleteAsync(equipment.EquipmentDataId);

            if (equipmentData == null)
            {
                return BadRequest();
            }

            await db.Equipments.DeleteAsync(equipment.Id);

            var model = ConvertEquipmentAndEquipmentDataToIndexViewModel(equipment, equipmentData);

            if (model == null)
            {
                return BadRequest();
            }

            return Ok(model);
        }


        private IndexEditEquipmentViewModel ConvertEquipmentAndEquipmentDataToIndexViewModel(Equipment equipment, EquipmentData equipmentData)
        {

            if (equipment == null || equipmentData == null)
            {
                return null;
            }

            IndexEditEquipmentViewModel model = new IndexEditEquipmentViewModel
            {
                Id = equipment.Id,
                EquipmentDataId = equipmentData.Id,
                Name = equipment.Name,
                Description = equipmentData.Description,
                Number = equipmentData.Number,
                WorkObjectId = equipment.WorkObjectId
            };

            return model;
        }
    }
}