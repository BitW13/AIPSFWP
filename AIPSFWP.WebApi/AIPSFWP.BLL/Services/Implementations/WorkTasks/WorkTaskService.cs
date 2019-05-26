using AIPSFWP.BLL.Services.Interfaces.WorkTasks;
using AIPSFWP.Common.Entities.WorkTasks;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.WorkTasks
{
    public class WorkTaskService : IWorkTaskService
    {
        private readonly IWorkTaskRepository db;

        public WorkTaskService(IWorkTaskRepository db)
        {
            this.db = db;
        }

        public async Task<WorkTask> CreateAsync(WorkTask item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<WorkTask> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkTask>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<WorkTask> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task<IEnumerable<WorkTask>> GetItemsByWorkObjectIdAsync(int id)
        {
            return await db.GetItemsByWorkObjectIdAsync(id);
        }

        public async Task UpdateAsync(WorkTask item)
        {
            await db.UpdateAsync(item);
        }
    }
}
