using Mic.Repository.Consts;
using Mic.Repository.Entities;
using System;
using System.Data;

namespace Mic.Repository 
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(DbContext dbContext) : base(dbContext){ }
        public override string TableName => DbNames.Table_Universities;
        public int Destroy(int id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, string name, DateTime Destroy_Date)
        {
            throw new NotImplementedException();
        }
        protected override University CreateEntity(IDataReader reader)
        {
            return new University
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                DestroyDate = reader.ToNullableDateTime("DestroyDate"),
            };
        }
    }
}
