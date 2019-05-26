using AIPSFWP.BLL.Services.Interfaces.WorkObjects;
using AIPSFWP.Common.Entities.WorkObjects;
using AIPSFWP.DAL.Repositories.Interfaces.WorkObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.WorkObjects
{
    public class WorkObjectService : IWorkObjectService
    {
        private readonly IWorkObjectRepository db;

        public WorkObjectService(IWorkObjectRepository db)
        {
            this.db = db;
        }

        public async Task<WorkObject> CreateAsync(WorkObject item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<WorkObject> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkObject>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<WorkObject> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(WorkObject item)
        {
            await db.UpdateAsync(item);
        }
    }
}
