using AIPSFWP.BLL.Services.Interfaces.Employees;
using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository db;

        public EmployeeService(IEmployeeRepository db)
        {
            this.db = db;
        }

        public async Task<Employee> CreateAsync(Employee item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<Employee> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(Employee item)
        {
            await db.UpdateAsync(item);
        }
    }
}
