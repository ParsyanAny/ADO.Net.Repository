using Mic.Repository.Entities;

namespace Mic.Repository
    public interface IStudentRepository : IBaseRepository<Student>
    {
        int Update(int id, string name, string surname, int gender_id, int university_id);
    }
}
