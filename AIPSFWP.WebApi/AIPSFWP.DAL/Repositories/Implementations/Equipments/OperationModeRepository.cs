using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Equipments
{
    public class OperationModeRepository : IOperationModeRepository
    {
        private readonly ProjectContext db;

        public OperationModeRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<OperationMode> CreateAsync(OperationMode item)
        {
            if (item != null)
            {
                db.OperationModes.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<OperationMode> DeleteAsync(int id)
        {
            OperationMode operationMode = await db.OperationModes.FindAsync(id);

            if (operationMode != null)
            {
                db.OperationModes.Remove(operationMode);

                await db.SaveChangesAsync();

                return operationMode;
            }

            return null;
        }

        public async Task<IEnumerable<OperationMode>> GetAllAsync()
        {
            return await db.OperationModes.ToListAsync();
        }

        public async Task<OperationMode> GetItemByIdAsync(int id)
        {
            return await db.OperationModes.FindAsync(id);
        }

        public async Task UpdateAsync(OperationMode item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
