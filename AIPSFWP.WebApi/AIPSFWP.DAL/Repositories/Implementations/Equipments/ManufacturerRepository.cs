using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.Equipments;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Equipments
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ProjectContext db;

        public ManufacturerRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<Manufacturer> CreateAsync(Manufacturer item)
        {
            if (item != null)
            {
                db.Manufacturers.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Manufacturer> DeleteAsync(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);

            if (manufacturer != null)
            {
                db.Manufacturers.Remove(manufacturer);

                await db.SaveChangesAsync();

                return manufacturer;
            }

            return null;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await db.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetItemByIdAsync(int id)
        {
            return await db.Manufacturers.FindAsync(id);
        }

        public async Task UpdateAsync(Manufacturer item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
