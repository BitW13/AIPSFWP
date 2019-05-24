using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.DAL.Contexts;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectContext db;

        public EmployeeRepository(ProjectContext db)
        {
            this.db = db;
        }
        public async Task<Employee> DeleteAsync(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);

            if (employee != null)
            {
                db.Employees.Remove(employee);

                await db.SaveChangesAsync();

                return employee;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetItemByIdAsync(int id)
        {
            return await db.Employees.FindAsync(id);
        }

        public async Task<Employee> CreateAsync(Employee item)
        {
            if (item != null)
            {
                db.Employees.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task UpdateAsync(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetItemsByWorkObjectIdAsync(int id)
        {
            var items = (await GetAllAsync()).ToList();

            return items.Where(x => x.WorkObjectId == id);
        }
    }
}
