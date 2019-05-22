using AIPSFWP.BLL.Services.Interfaces;
using AIPSFWP.Common.Entities;
using AIPSFWP.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository db;

        public AdminService(IAdminRepository db)
        {
            this.db = db;
        }

        public async Task<Admin> CreateAsync(Admin item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<Admin> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Admin> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Admin item)
        {
            await db.UpdateAsync(item);
        }
    }
}
