using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MvcIntroWebApp.Models;
using MvcIntroWebApp.Models.ViewModel;

namespace MvcIntroWebApp.Gateway
{
    public class StudentGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public StudentGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }

        public int Save(Student student)
        {
            string query = "INSERT INTO Student VALUES(@name,@address,@departmentId)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@departmentId", student.DepartmentId);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public StudentViewModel GetStudentById(int id)
        {
            string query = "SELECT s.Id AS StudentId, s.Name AS StudentName, " +
                           "s.Address, s.DepartmentId, d.Name AS DepartmentName " +
                           "FROM Student AS s INNER JOIN Department AS d ON s.DepartmentId = d.Id WHERE s.Id = @id";

            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);            
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            StudentViewModel student = null;
            if (Reader.HasRows)
            {
                student = new StudentViewModel();
                student.StudentId = Convert.ToInt32(Reader["StudentId"]);
                student.StudentName = Reader["StudentName"].ToString();
                student.Address = Reader["Address"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                student.DepartmentName = Reader["DepartmentName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }

        public List<StudentViewModel> GetStudentsByDepartmentId(int departmentId)
        {
            string query = "SELECT s.Id As StudentId, s.Name As StudentName, s.Address, s.DepartmentId, d.Name AS DepartmentName FROM Student AS s INNER JOIN Department AS d ON s.DepartmentId = d.Id WHERE s.DepartmentId ="+departmentId;

            Command = new SqlCommand(query, Connection);
            //Command.Parameters.AddWithValue("@departmentId", departmentId);
            Connection.Open();
            Reader = Command.ExecuteReader();            
            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();

            while (Reader.Read())
            {
                StudentViewModel student = new StudentViewModel();
                student.StudentId = Convert.ToInt32(Reader["StudentId"]);
                student.StudentName = Reader["StudentName"].ToString();
                student.Address = Reader["Address"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                student.DepartmentName = Reader["DepartmentName"].ToString();
                studentViewModels.Add(student);
            }

            Reader.Close();
            Connection.Close();
            return studentViewModels;
        }



    }
}