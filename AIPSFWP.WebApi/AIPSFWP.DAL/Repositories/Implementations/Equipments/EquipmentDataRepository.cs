using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Equipments
{
    public class EquipmentDataRepository : IEquipmentDataRepository
    {
        private readonly ProjectContext db;

        public EquipmentDataRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<EquipmentData> CreateAsync(EquipmentData item)
        {
            if (item != null)
            {
                db.EquipmentDatas.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<EquipmentData> DeleteAsync(int id)
        {
            EquipmentData equipmentData = await db.EquipmentDatas.FindAsync(id);

            if (equipmentData != null)
            {
                db.EquipmentDatas.Remove(equipmentData);

                await db.SaveChangesAsync();

                return equipmentData;
            }

            return null;
        }

        public async Task<IEnumerable<EquipmentData>> GetAllAsync()
        {
            return await db.EquipmentDatas.ToListAsync();
        }

        public async Task<EquipmentData> GetItemByIdAsync(int id)
        {
            return await db.EquipmentDatas.FindAsync(id);
        }

        public async Task UpdateAsync(EquipmentData item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
