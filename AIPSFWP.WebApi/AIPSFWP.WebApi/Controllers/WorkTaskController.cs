﻿using AIPSFWP.BLL.BusinessLogic;
using AIPSFWP.Common.Entities.WorkTasks;
using AIPSFWP.WebApi.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTaskController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBusinessLogic db;

        public WorkTaskController(IBusinessLogic db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("byworkobjectid/{id}")]
        public async Task<IEnumerable<IndexEditWorkTaskViewModel>> GetByWorkObjectId(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var workTasks = await db.WorkTasks.GetItemsByWorkObjectIdAsync(id);

            List<IndexEditWorkTaskViewModel> models = mapper.Map<List<IndexEditWorkTaskViewModel>>(workTasks);

            return models;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexEditWorkTaskViewModel>> Get()
        {
            var workTasks = await db.WorkTasks.GetAllAsync();

            List<IndexEditWorkTaskViewModel> models = mapper.Map<List<IndexEditWorkTaskViewModel>>(workTasks);

            return models;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            WorkTask workTask = await db.WorkTasks.GetItemByIdAsync(id);

            if (workTask == null)
            {
                return NotFound();
            }

            IndexEditWorkTaskViewModel model = mapper.Map<IndexEditWorkTaskViewModel>(workTask);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateWorkTaskViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            WorkTask workTask = await db.WorkTasks.CreateAsync(mapper.Map<WorkTask>(model));

            IndexEditWorkTaskViewModel newModel = mapper.Map<IndexEditWorkTaskViewModel>(workTask);

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

            await db.WorkTasks.UpdateAsync(mapper.Map<WorkTask>(model));

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            WorkTask workTask = await db.WorkTasks.GetItemByIdAsync(id);

            if (workTask == null)
            {
                return BadRequest();
            }

            await db.WorkTasks.DeleteAsync(workTask.Id);

            IndexEditWorkTaskViewModel model = mapper.Map<IndexEditWorkTaskViewModel>(workTask);

            return Ok(model);
        }
    }
}