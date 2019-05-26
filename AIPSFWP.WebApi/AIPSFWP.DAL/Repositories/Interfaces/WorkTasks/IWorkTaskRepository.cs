using AIPSFWP.Common.Entities.WorkTasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Interfaces.WorkTasks
{
    public interface IWorkTaskRepository : IRepository<WorkTask>
    {
        Task<IEnumerable<WorkTask>> GetItemsByWorkObjectIdAsync(int id);
    }
}
