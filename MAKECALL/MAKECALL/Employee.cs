using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAKECALL
{
    public class Employee
    {
        [AutoIncrement,PrimaryKey]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
}
