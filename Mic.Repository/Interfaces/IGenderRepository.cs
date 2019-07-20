using Mic.Repository.Entities;

namespace Mic.Repository
{
    public interface IGenderRepository : IBaseRepository<Gender>
    {
        int Update(int id, string name);
    }
}
