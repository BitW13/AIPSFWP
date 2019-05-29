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
    public class ManufacturerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public ManufacturerController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ManufacturerViewModel>> Get()
        {
            var manufacturers = await db.Manufacturers.GetAllAsync();

            List<ManufacturerViewModel> models = mapper.Map<List<ManufacturerViewModel>>(manufacturers);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Manufacturer manufacturer = await db.Manufacturers.GetItemByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            ManufacturerViewModel model = mapper.Map<ManufacturerViewModel>(manufacturer);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ManufacturerViewModel model)
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

            Manufacturer manufacturer = await db.Manufacturers.CreateAsync(mapper.Map<Manufacturer>(model));

            ManufacturerViewModel newModel = mapper.Map<ManufacturerViewModel>(manufacturer);

            return Ok(newModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ManufacturerViewModel model)
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

            await db.Manufacturers.UpdateAsync(mapper.Map<Manufacturer>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Manufacturer manufacturer = await db.Manufacturers.GetItemByIdAsync(id);

            if (manufacturer == null)
            {
                return BadRequest();
            }

            await db.Manufacturers.DeleteAsync(manufacturer.Id);

            ManufacturerViewModel model = mapper.Map<ManufacturerViewModel>(manufacturer);

            return Ok(model);
        }
    }
}