using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Equipments
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository db;

        public EquipmentService(IEquipmentRepository db)
        {
            this.db = db;
        }

        public async Task<Equipment> CreateAsync(Equipment item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<Equipment> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Equipment> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Equipment item)
        {
            await db.UpdateAsync(item);
        }
    }
}
