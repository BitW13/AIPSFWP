using AIPSFWP.Common.Entities.WorkTasks;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.WorkTasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.WorkTasks
{
    public class WorkTaskRepository : IWorkTaskRepository
    {
        private readonly ProjectContext db;

        public WorkTaskRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<WorkTask> CreateAsync(WorkTask item)
        {
            if (item != null)
            {
                db.WorkTasks.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<WorkTask> DeleteAsync(int id)
        {
            WorkTask workTask = await db.WorkTasks.FindAsync(id);

            if (workTask != null)
            {
                db.WorkTasks.Remove(workTask);

                await db.SaveChangesAsync();

                return workTask;
            }

            return null;
        }

        public async Task<IEnumerable<WorkTask>> GetAllAsync()
        {
            return await db.WorkTasks.ToListAsync();
        }

        public async Task<WorkTask> GetItemByIdAsync(int id)
        {
            return await db.WorkTasks.FindAsync(id);
        }

        public async Task<IEnumerable<WorkTask>> GetItemsByWorkObjectIdAsync(int id)
        {
            var items = (await GetAllAsync()).ToList();

            return items.Where(x => x.WorkObjectId == id);
        }

        public async Task UpdateAsync(WorkTask item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
