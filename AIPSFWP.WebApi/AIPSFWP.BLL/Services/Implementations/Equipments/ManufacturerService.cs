using AIPSFWP.BLL.Services.Interfaces.Equipments;
using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Equipments
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository db;

        public ManufacturerService(IManufacturerRepository db)
        {
            this.db = db;
        }

        public async Task<Manufacturer> CreateAsync(Manufacturer item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<Manufacturer> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Manufacturer> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Manufacturer item)
        {
            await db.UpdateAsync(item);
        }
    }
}
