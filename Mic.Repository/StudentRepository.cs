using Mic.Repository.Consts;
using Mic.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mic.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        { }

        public override string TableName => DbNames.Table_Students;

        protected override Student CreateEntity(IDataReader reader)
        {
            return new Student
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader[nameof(Student.Surname)],
                Gender_Id = (byte)reader["Gender_Id"],
                University_Id = (int)reader["University_Id"],
            };
        }
    }
}
