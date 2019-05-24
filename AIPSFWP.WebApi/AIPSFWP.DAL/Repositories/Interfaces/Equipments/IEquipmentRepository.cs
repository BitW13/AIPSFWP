using AIPSFWP.Common.Entities.Equipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Interfaces.Equipments
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<IEnumerable<Equipment>> GetItemsByWorkObjectIdAsync(int id);
    }
}
