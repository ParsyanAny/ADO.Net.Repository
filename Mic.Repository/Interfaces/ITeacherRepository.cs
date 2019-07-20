using Mic.Repository.Entities;

namespace Mic.Repository
{
    public interface ITeacherInterface : IBaseRepository<Teacher>
    {
        int Update(int id, string name, string surname, int gender_id);
    }
}
