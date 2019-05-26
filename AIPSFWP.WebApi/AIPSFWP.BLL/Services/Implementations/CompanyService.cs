using AIPSFWP.BLL.Services.Interfaces;
using AIPSFWP.Common.Entities;
using AIPSFWP.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository db;

        public CompanyService(ICompanyRepository db)
        {
            this.db = db;
        }

        public async Task<Company> CreateAsync(Company item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<Company> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Company> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Company item)
        {
            await db.UpdateAsync(item);
        }
    }
}
