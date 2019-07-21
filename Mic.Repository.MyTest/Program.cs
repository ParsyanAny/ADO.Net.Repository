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

            //IStudentRepository st = new StudentRepository(dbContext);
            //var stu = new Student { Gender_Id = 2};
            //_ = st.Update(stu, 3); +-
            //st.Insert(stu); //+
            //st.Delete(78);   //+

            //ITeacherInterface tea = new TeacherRepository(dbContext);
            //var t = new Teacher { Name = "a", Surname = "a1", Gender_Id = 1 };
            //_ = tea.Update(t, 1); // -
            //tea.Delete(8); //-
            //tea.Insert(t); // -

            //IUniversityRepository uni = new UniversityRepository(dbContext);
            //var un = new University {Name = "MOMO"};
            ////uni.Update(un,3);  //+
            //uni.Insert(un);  //+
            //uni.Delete(46); //+

        }
    }
}
