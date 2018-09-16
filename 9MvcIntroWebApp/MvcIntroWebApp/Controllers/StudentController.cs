using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIntroWebApp.Manager;
using MvcIntroWebApp.Models;

namespace MvcIntroWebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager studentManager;
        public StudentController()
        {
            studentManager = new StudentManager();
        }
        public string Index()
        {
            return "Hello from student/index";
        }

        [HttpGet]
        public ActionResult Save()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            string message = studentManager.Save(student);
            ViewBag.Message = message;

            return View();
        }














        public ActionResult StudentDetails(int id)
        {
            //Student student = studentManager.GetStudentById(id);
            //ViewBag.Student = student;
            //ViewBag.Message ="Hello From StudentDetails";

            List<Student> students = GetAllStudent();
            //ViewBag.StudentList = students;
            return View(students);
        }

        public List<Student> GetAllStudent()
        {
            return new List<Student>
            {
                new Student(){Id = 1,Name = "Ruhul",Address = "205/a",Department = "CSE"},
                new Student(){Id = 2,Name = "Kuddus",Address = "206/a",Department = "EEE"},
                new Student(){Id = 3,Name = "Nayem",Address = "207/a",Department = "ETE"},
            };
        }


        //public string Search(int? id)
        //{           
        //    return 
        //}

        //public string Search()
        //{
        //    return "Search method without parameter";
        //}



    }
}