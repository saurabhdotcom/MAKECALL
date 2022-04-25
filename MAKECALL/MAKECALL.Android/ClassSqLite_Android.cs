using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MAKECALL;
using MAKECALL.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClassSqLite_Android)) ]
namespace MAKECALL.Droid
{
    public class ClassSqLite_Android : ISqlLite
    {
        SQLiteConnection Con = null;
        public SQLiteConnection CreateConnection()
        {
            string dbname = "pmsl.db3";
            string dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string finalpath= Path.Combine(dbpath, dbname);
            Con = new SQLiteConnection(finalpath);
            Con.CreateTable<Employee>();
            return Con;
        }

        public bool DeleteEmployee(int employeeid)
        {
            try
            {
                string query = $"delete  from Employee where employeeid={employeeid}";
                int result = Con.Execute(query);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }

        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> lstEmployee=new List<Employee>();
            try
            {
                string query = "select * from Employee";
                lstEmployee = Con.Query<Employee>(query);
                return lstEmployee;
            }
            catch
            {
               return lstEmployee;
            }

           
        }

        public bool SaveEmployee(Employee employee)
        {
            try
            {
               int result= Con.Insert(employee);
                if(result>0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
                
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                string query = $"update Employee set EmployeeName='{employee.EmployeeName}', email='{employee.Email}' , mobile='{employee.Mobile}'  where EmployeeId={employee.EmployeeId}";
                int result = Con.Execute(query);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }
    }
}