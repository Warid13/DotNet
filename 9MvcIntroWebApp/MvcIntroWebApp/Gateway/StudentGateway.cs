using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MvcIntroWebApp.Models;

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
            string query = "INSERT INTO Student VALUES(@name,@address,@department)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@department", student.Department);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public Student GetStudentById(int id)
        {
            string query = "SELECT * FROM Student WHERE Id = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);            
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Student student = null;
            if (Reader.HasRows)
            {
                student = new Student();
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.Name = Reader["Name"].ToString();
                student.Address = Reader["Address"].ToString();
                student.Department= Reader["Department"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }
    }
}