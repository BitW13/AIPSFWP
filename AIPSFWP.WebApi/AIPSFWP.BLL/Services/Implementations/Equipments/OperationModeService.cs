using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Equipments
{
    public class OperationModeService : IOperationModeService
    {
        private IOperationModeRepository db;

        public OperationModeService(IOperationModeRepository db)
        {
            this.db = db;
        }

        public async Task<OperationMode> CreateAsync(OperationMode item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<OperationMode> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<OperationMode>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<OperationMode> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(OperationMode item)
        {
            await db.UpdateAsync(item);
        }
    }
}
