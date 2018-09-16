using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIntroWebApp.Manager;
using MvcIntroWebApp.Models;
using MvcIntroWebApp.Models.ViewModel;

namespace MvcIntroWebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager studentManager;
        private DepartmentManager departmentManager;
        public StudentController()
        {
            studentManager = new StudentManager();
            departmentManager = new DepartmentManager();
        }
        public string Index()
        {
            return "Hello from student/index";
        }

        [HttpGet]
        public ActionResult Save()
        {

            ViewBag.Departments = departmentManager.GetDepartmentsForDropdown();            
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (ModelState.IsValid)
            {
                string message = studentManager.Save(student);
                ViewBag.Message = message;
                ViewBag.Departments = departmentManager.GetDepartmentsForDropdown();
                return View();
            }
            else
            {
                ViewBag.Departments = departmentManager.GetDepartmentsForDropdown();
                ViewBag.Message = "Model State Is Invalid";
                return View();
            }
                               
        }

        public ActionResult ViewStudentsByDepartment()
        {
            ViewBag.Departments = departmentManager.GetDepartmentsForDropdown();
            return View();
        }





        public JsonResult GetStudentsByDepartmentId(int deptId)
        {
            List<StudentViewModel> studentViewModels = studentManager.GetStudentsByDepartmentId(deptId);
            JsonResult jsonResult = Json(studentViewModels);
            return jsonResult;
        }












        //public ActionResult StudentDetails(int id)
        //{
        //    //Student student = studentManager.GetStudentById(id);
        //    //ViewBag.Student = student;
        //    //ViewBag.Message ="Hello From StudentDetails";

        //    List<Student> students = GetAllStudent();
        //    //ViewBag.StudentList = students;
        //    return View(students);
        //}

        //public List<Student> GetAllStudent()
        //{
        //    return new List<Student>
        //    {
        //        new Student(){Id = 1,Name = "Ruhul",Address = "205/a",Department = "CSE"},
        //        new Student(){Id = 2,Name = "Kuddus",Address = "206/a",Department = "EEE"},
        //        new Student(){Id = 3,Name = "Nayem",Address = "207/a",Department = "ETE"},
        //    };
        //}


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