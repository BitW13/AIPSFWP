using AIPSFWP.Common.Entities.Equipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.BLL.Services.Interfaces.Equipments
{
    public interface IEquipmentService : IService<Equipment>
    {
        Task<IEnumerable<Equipment>> GetItemsByWorkObjectIdAsync(int id);
    }
}
