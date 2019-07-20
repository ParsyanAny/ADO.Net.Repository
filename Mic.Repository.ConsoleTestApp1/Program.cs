using Mic.Repository.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Mic.Repository.ConsoleTestApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            #region ReflectionTest
            //var uni1 = new University() { Id = 1, Name = "U1", DestroyDate = DateTime.Now};
            //var uni2 = new University() { Id = 2, Name = "U2"};

            //Type type = typeof(University);
            //foreach (var item in type.GetProperties())
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.PropertyType);
            //    object value = item.GetValue(uni2);
            //    Console.WriteLine(value);
            //    Console.WriteLine();
            //}
            //    Console.ReadLine();
            #endregion
            var dbContext = new DbContext(conStr);

            //var stRepository = new StudentRepository(dbContext);
            //List<Student> students = stRepository.SelectAll();

            IUniversityRepository university = new UniversityRepository(dbContext);
            List<University> uns = university.SelectAll().ToList();
            var uni1 = new University{Name = "U3" };
            int id = university.Insert(uni1);
            university.Destroy(id);
            
            //University un1 = university.FirstOrDefault(1);
        }
    }
}
