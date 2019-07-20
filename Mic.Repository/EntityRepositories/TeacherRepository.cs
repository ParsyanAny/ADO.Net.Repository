using Mic.Repository.Consts;
using Mic.Repository.Entities;
using System.Data;

namespace Mic.Repository
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherInterface
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext){ }
        public override string TableName => DbNames.Table_Students;

        protected override Teacher CreateEntity(IDataReader reader)
        {
            return new Teacher
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader[nameof(Teacher.Surname)],
                Gender_Id = (byte)reader["Gender_Id"],
            };
        }
        public int Update(int id, string name, string surname, int gender_id)
        {
            throw new System.NotImplementedException();
        }

    }

}
