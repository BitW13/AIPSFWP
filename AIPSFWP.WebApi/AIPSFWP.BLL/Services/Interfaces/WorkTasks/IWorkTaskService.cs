using AIPSFWP.Common.Entities.WorkTasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Interfaces.WorkTasks
{
    public interface IWorkTaskService : IService<WorkTask>
    {
        Task<IEnumerable<WorkTask>> GetItemsByWorkObjectIdAsync(int id);
    }
}
