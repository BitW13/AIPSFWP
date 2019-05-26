using AIPSFWP.Common.Entities.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Interfaces.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetItemsByWorkObjectIdAsync(int id);
    }
}
