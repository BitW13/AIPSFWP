using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Equipments
{
    public class EquipmentDataService : IEquipmentDataService
    {
        private readonly IEquipmentDataRepository db;

        public EquipmentDataService(IEquipmentDataRepository db)
        {
            this.db = db;
        }

        public async Task<EquipmentData> CreateAsync(EquipmentData item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<EquipmentData> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<EquipmentData>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<EquipmentData> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(EquipmentData item)
        {
            await db.UpdateAsync(item);
        }
    }
}
