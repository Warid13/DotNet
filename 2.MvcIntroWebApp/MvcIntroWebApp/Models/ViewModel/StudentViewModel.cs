using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIntroWebApp.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}