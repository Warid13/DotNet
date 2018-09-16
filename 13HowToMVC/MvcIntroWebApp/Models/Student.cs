using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcIntroWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Name")]        
        public string Name { get; set; }
        [EmailAddress]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Provide Department")]
        public int DepartmentId { get; set; }
    }
}