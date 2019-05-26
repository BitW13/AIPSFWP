using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Employees
{
    public class EmployeeDataRepository : IEmployeeDataRepository
    {
        private readonly ProjectContext db;

        public EmployeeDataRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<EmployeeData> CreateAsync(EmployeeData item)
        {
            if (item != null)
            {
                db.EmployeesDatas.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<EmployeeData> DeleteAsync(int id)
        {
            EmployeeData employeeData = await db.EmployeesDatas.FindAsync(id);

            if (employeeData != null)
            {
                db.EmployeesDatas.Remove(employeeData);

                await db.SaveChangesAsync();

                return employeeData;
            }

            return null;
        }

        public async Task<IEnumerable<EmployeeData>> GetAllAsync()
        {
            return await db.EmployeesDatas.ToListAsync();
        }

        public async Task<EmployeeData> GetItemByIdAsync(int id)
        {
            return await db.EmployeesDatas.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeData item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
