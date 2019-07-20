using Mic.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mic.Repository.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * From students";
                    //cmd.CommandText = string.Format(SelectAll, Tables.students);

                    IDataReader reader = cmd.ExecuteReader();
                    if(reader.FieldCount > 0)
                    {
                        var students = new List<Student>();
                        while(reader.Read())
                        {
                            var st = new Student
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Surname = (string)reader[nameof(Student.Surname)],
                                Gender_Id = (byte)reader["Gender_Id"],
                                University_Id = (int)reader["University_Id"],
                            };

                            students.Add(st);
                        }
                    }
                }
            }
        }

        const string SelectAll = "Select * From {0}";

        public class Tables
        {
            public const string students = "students";
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int University_Id { get; set; }
            public int Gender_Id { get; set; }
        }
    }
}
