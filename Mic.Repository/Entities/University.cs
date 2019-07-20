using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.Repository.Entities
{
    public class University 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DestroyDate { get; set; }
    }
}
