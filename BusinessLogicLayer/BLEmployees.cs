using RepositoryEmployee;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IEmployeeRepository _rep;

       public BLEmployees(IEmployeeRepository rep)
        {
            _rep = rep;
        }

        public void AddEmployee(Employee emp)
        {
            _rep.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _rep.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            _rep.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return _rep.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _rep.GetEmployee(id);
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            return _rep.SearchEmployees(searchTerm);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            
           
            try
            {
                double suma = 0;
                Employee em = _rep.GetEmployee(idEmployee);
      
		        if (em != null)
                {
                    if (em is PartTimeEmployee)
                    {
                        PartTimeEmployee p = (PartTimeEmployee)em;
                        suma = p.HourlyRate * hours;

                    }
                    else
                    {
                        Console.WriteLine("No se puede calcular Salario. Empleado Full Time");
                        throw new System.Exception("No es part time");
                    }
                }
                return suma;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
            
        }
    }
}
