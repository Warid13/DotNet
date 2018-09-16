using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIntroWebApp.Gateway;
using MvcIntroWebApp.Models;

namespace MvcIntroWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;
        public DepartmentManager()
        {
            departmentGateway = new DepartmentGateway();
        }
        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }

        public List<SelectListItem> GetDepartmentsForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem(){ Text = "--Select--", Value = ""});

            foreach (Department department in GetAllDepartment())
            {
                SelectListItem selectList = new SelectListItem();
                selectList.Text = department.Name;                
                selectList.Value = department.Id.ToString();
                selectListItems.Add(selectList);
            }
            return selectListItems;
        }


    }
}