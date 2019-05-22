using AIPSFWP.Common.Entities.WorkObjects;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.WorkObjects
{
    public class WorkObjectRepository : IWorkObjectRepository
    {
        private readonly ProjectContext db;

        public WorkObjectRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<WorkObject> CreateAsync(WorkObject item)
        {
            if (item != null)
            {
                db.WorkObjects.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<WorkObject> DeleteAsync(int id)
        {
            WorkObject workObject = await db.WorkObjects.FindAsync(id);

            if (workObject != null)
            {
                db.WorkObjects.Remove(workObject);

                await db.SaveChangesAsync();

                return workObject;
            }

            return null;
        }

        public async Task<IEnumerable<WorkObject>> GetAllAsync()
        {
            return await db.WorkObjects.ToListAsync();
        }

        public async Task<WorkObject> GetItemByIdAsync(int id)
        {
            return await db.WorkObjects.FindAsync(id);
        }

        public async Task UpdateAsync(WorkObject item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
