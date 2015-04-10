using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesMock : IDALEmployees
    {
        static EmployeeDBContext db = new EmployeeDBContext();

        private List<Employee> employeesRepository = new List<Employee>()
        {
            new PartTimeEmployee(){HourlyRate = 100},
            new PartTimeEmployee(){HourlyRate = 150},
            new PartTimeEmployee(){HourlyRate = 200},
            new PartTimeEmployee(){HourlyRate = 250},
            new PartTimeEmployee(){HourlyRate = 300},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
        };

        public void AddEmployee(Employee emp)
        {
            try
            {
                db.Employee.Add(emp);
                db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(int id)
        {
            var matched_Employee = (from c in db.Employee
                                    where c.Id == id
                                    select c).SingleOrDefault();
            try
            {
                db.Employee.Remove(matched_Employee);
                db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                var empleado = db.Employee
                    .Where(w => w.Id == emp.Id)
                    .SingleOrDefault();

                if (emp != null)
                {
                    empleado.Name = emp.Name;
                    empleado.StartDate = emp.StartDate;
                    db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> empleados = new List<Employee>();
            try
            {
                empleados = employeesRepository.ToList();
                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = null;

            try
            {
                emp = db.Employee
                   .Where(w => w.Id == id)
                   .SingleOrDefault();

                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            List<Employee> empleados = new List<Employee>();
            try
            {
                empleados = db.Employee
                    .Where(w => w.Name == searchTerm).ToList();
                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //-------------------------------------------------------------------------------------//

        public void AddListEmployee(List<Employee> emps)
        {
             var list = from e in db.Employee
                   orderby e.Id ascending
                   select e;

             try
             {
                 foreach (Employee e in employeesRepository)
                 {
                     db.Employee.Add(e);
                 }
             }
             catch (Exception ex)
             {
                 
                 throw ex;
             }
        }

        public void DeleteListEmployee(List<Employee> emps)
        {
            var list = from e in db.Employee
                       orderby e.Id ascending
                       select e;

            try
            {
                foreach (Employee e in employeesRepository)
                {
                    db.Employee.Remove(e);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<FullTimeEmployee> GetAllEmployeeSalaryAbove(int minsalary)
        {
            List<FullTimeEmployee> listfull = new List<FullTimeEmployee>();

            try
            {
                var list = listfull.Where<FullTimeEmployee>(e => e.Salary >= minsalary).ToList();
                   
                return listfull;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

       
}
