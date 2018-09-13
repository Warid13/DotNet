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
    public class DepartmentGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }
        public DepartmentGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["UniversityDBConString"].ConnectionString;

            Connection = new SqlConnection(connectionString);
        }


        public List<Department> GetAllDepartment()
        {
            string query = "SELECT * FROM Department";

            Command = new SqlCommand(query, Connection);           
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Name = Reader["Name"].ToString();
                departments.Add(department);
            }

            Reader.Close();
            Connection.Close();
            return departments;
        }
    }
}