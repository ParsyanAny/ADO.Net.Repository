using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.Repository.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender_Id { get; set; }
    }
}
