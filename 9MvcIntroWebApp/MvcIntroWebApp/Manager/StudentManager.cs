using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcIntroWebApp.Gateway;
using MvcIntroWebApp.Models;

namespace MvcIntroWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;
        public StudentManager()
        {
            studentGateway= new StudentGateway();
        }

        public string Save(Student student)
        {
            int rowAffect = studentGateway.Save(student);
            if (rowAffect>0)
            {
                return "Save Successful";
            }
            else
            {
                return "Save Failed";
            }
        }

        public Student GetStudentById(int id)
        {
            return studentGateway.GetStudentById(id);
        }
    }
}