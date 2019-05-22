using AIPSFWP.BLL.Services.Interfaces.Employees;
using AIPSFWP.Common.Entities.Employees;
using AIPSFWP.DAL.Repositories.Interfaces.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Implementations.Employees
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IEmployeeDataRepository db;

        public EmployeeDataService(IEmployeeDataRepository db)
        {
            this.db = db;
        }

        public async Task<EmployeeData> CreateAsync(EmployeeData item)
        {
            if (item == null)
            {
                return null;
            }

            return await db.CreateAsync(item);
        }

        public async Task<EmployeeData> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeData>> GetAllAsync()
        {
            return await db.GetAllAsync();
        }

        public async Task<EmployeeData> GetItemByIdAsync(int id)
        {
            return await db.GetItemByIdAsync(id);
        }

        public async Task UpdateAsync(EmployeeData item)
        {
            await db.UpdateAsync(item);
        }
    }
}
