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


            #region StudentTest
            IStudentRepository students = new StudentRepository(dbContext);
            //var stu = new Student { Name = "HHH", Surname = "HHH", University_Id = 1, Gender_Id = 2 };
            //IEnumerable<Student> sts2 sts1 = students.SelectAll();
            //IEnumerable<Student> sts2 = students.SelectWhere("Name = 'A'");
            //Student st1 = students.SelectOne("Name = 'A'");
            //Student st2 = students.SelectOne(2);
            //Student st3 = students.FirstOrDefault();
            //IEnumerable<Student> sts = students.SelectAll();
            //_ = students.Update(stu, 3); //+-
            //students.Insert(stu); //+
            //students.Delete(78);   //+
            #endregion

            #region TeacherTest
            //ITeacherInterface tea = new TeacherRepository(dbContext);
            //var t = new Teacher { Name = "a", Surname = "a1", Gender_Id = 1 };
            //_ = tea.Update(t, 1); // -
            //tea.Delete(8); //-
            //tea.Insert(t); // -
            #endregion

            #region UniversityTest
            //IUniversityRepository uni = new UniversityRepository(dbContext);
            //var un = new University {Name = "MOMO"};
            ////uni.Update(un,3);  //+
            //uni.Insert(un);  //+
            //uni.Delete(46); //+
            #endregion
        }
    }
}
