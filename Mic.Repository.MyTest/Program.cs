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
            //var stu = new Student {Id =1, Name = "Test", Surname = "T", University_Id = 1, Gender_Id = 2 };
            //int a = students.InsertOrUpdate(stu);
            //IEnumerable<Student> sts2 sts1 = students.SelectAll();
            //IEnumerable<Student> sts2 = students.SelectWhere("Name = 'A'");
            //Student st1 = students.SelectOne("Name = 'A'");
            //Student st2 = students.SelectOne(2);
            //Student st3 = students.FirstOrDefault();
            //IEnumerable<Student> sts = students.SelectAll();
            //students.Insert(stu); 
            //_ = students.Update(stu, 3);      // Update with Id
            //_ = students.Update(stu);         // Update without Id (write id in your entity)
            //students.InsertOrUpdate(stu);
            //students.Delete(78);   
            #endregion

            #region TeacherTest
            //ITeacherInterface teachers = new TeacherRepository(dbContext);
            //var t = new Teacher { Name = "Test", Surname = "T", Gender_Id = 1 };
            //_ = teachers.Update(t, 1); 
            //teachers.Delete(8); 
            //teachers.Insert(t); 
            #endregion

            #region UniversityTest
            //IUniversityRepository universities = new UniversityRepository(dbContext);
            //var un = new University { Name = "TestUniversity" };
            //universities.Update(un,3);  
            //universities.Update(un);  
            //universities.Insert(un);  
            //universities.Delete(46); 
            #endregion
        }
    }
}
