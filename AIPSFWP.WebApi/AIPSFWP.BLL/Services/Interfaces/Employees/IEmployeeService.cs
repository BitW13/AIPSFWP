using AIPSFWP.Common.Entities.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Interfaces.Employees
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<IEnumerable<Employee>> GetItemsByWorkObjectIdAsync(int id);
    }
}
