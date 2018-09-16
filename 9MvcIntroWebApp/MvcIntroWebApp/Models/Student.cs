using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIntroWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}