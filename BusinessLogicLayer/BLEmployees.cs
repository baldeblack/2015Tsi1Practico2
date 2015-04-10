using DataAccessLayer;
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
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Employee emp)
        {
            _dal.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            _dal.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return _dal.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _dal.GetEmployee(id);
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            return _dal.SearchEmployees(searchTerm);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            
           
            try
            {
                double suma = 0;
                Employee em = _dal.GetEmployee(idEmployee);
      
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
