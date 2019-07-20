using Mic.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mic.Repository.MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=ANY;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var dbContext = new DbContext(conStr);

            IStudentRepository st = new StudentRepository(dbContext);
            var stu = new Student { Name = "A", Surname = "B", Gender_Id = 1, University_Id = 1 };
            st.SelectAll();
            //st.Insert(stu); //+
            //st.Delete(78);   //+

            //ITeacherInterface tea = new TeacherRepository(dbContext);
            //var t = new Teacher {Name = "A", Surname = "A1", Gender_Id = 1};
            //tea.Delete(8); //-
            // tea.Insert(t); // -

            //IUniversityRepository uni = new UniversityRepository(dbContext);
            //var un = new University { Name = "TestUniNow", DestroyDate = DateTime.Now };
            //uni.Insert(un);  //-
            //uni.Delete(53); //+

        }
    }
}
