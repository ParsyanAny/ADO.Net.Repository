using Mic.Repository.Consts;
using Mic.Repository.Entities;
using System.Data;

namespace Mic.Repository
{ 
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DbContext dbContext) : base(dbContext) { }

        public override string TableName => DbNames.Table_Gender;
        
        protected override Gender CreateEntity(IDataReader reader)
        {
            return new Gender
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
            };
        }
        public int Update(int id, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}

