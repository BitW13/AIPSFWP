using AIPSFWP.Common.Entities;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ProjectContext db;

        public CompanyRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<Company> CreateAsync(Company item)
        {
            if (item != null)
            {
                db.Companies.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Company> DeleteAsync(int id)
        {
            Company company = await db.Companies.FindAsync(id);

            if (company != null)
            {
                db.Companies.Remove(company);

                await db.SaveChangesAsync();

                return company;
            }

            return null;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await db.Companies.ToListAsync();
        }

        public async Task<Company> GetItemByIdAsync(int id)
        {
            return await db.Companies.FindAsync(id);
        }

        public async Task UpdateAsync(Company item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
