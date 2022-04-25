using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAKECALL
{
    public interface ISqlLite
    {
        SQLiteConnection CreateConnection();

        bool SaveEmployee(Employee employee);

        bool DeleteEmployee(int employeeid);
        List<Employee> GetAllEmployee();
        bool UpdateEmployee(Employee employee);
    }
}
