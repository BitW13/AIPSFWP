using AIPSFWP.Common.Entities;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ProjectContext db;

        public AdminRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<Admin> CreateAsync(Admin item)
        {
            if (item != null)
            {
                db.Admins.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Admin> DeleteAsync(int id)
        {
            Admin admin = await db.Admins.FindAsync(id);

            if (admin != null)
            {
                db.Admins.Remove(admin);

                await db.SaveChangesAsync();

                return admin;
            }

            return null;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await db.Admins.ToListAsync();
        }

        public async Task<Admin> GetItemByIdAsync(int id)
        {
            return await db.Admins.FindAsync(id);
        }

        public async Task UpdateAsync(Admin item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
