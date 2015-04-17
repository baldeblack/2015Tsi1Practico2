using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEmployee
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee emp);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employee emp);

        List<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        List<Employee> SearchEmployees(string searchTerm);
    }
}
