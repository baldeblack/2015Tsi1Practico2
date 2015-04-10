using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
     public class DALEmployeesEF : IDALEmployees
    {
        static EmployeeDBContext db = new EmployeeDBContext();
        
        // agrego empleado
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

        // borro empleado
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

        // actualizo empleado
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

        // listo empleado
        public List<Employee> GetAllEmployees()
        {
            List<Employee> empleados = new List<Employee>();   
            try
            {
                empleados = db.Employee.ToList();
                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // obtengo empleado
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

        // busco empleados    
        public List<Employee> SearchEmployees(string searchTerm)
        {
            List<Employee> empleados = new List<Employee>();   
            try
            {
                empleados =  db.Employee
                    .Where(w => w.Name == searchTerm).ToList();
                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
