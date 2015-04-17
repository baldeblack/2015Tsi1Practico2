using RepositoryEmployee;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryEF
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        //Contexto db = new Contexto();

        public void AddEmployee(Employee emp)
        {
            try
            {
                Insertar(emp);
                GuardarCambios();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // borro empleado
        public void DeleteEmployee(int id)
        {

             try
            {
                Employee emp = ObtenerPorId(id);
                Eliminar(emp);
                GuardarCambios();
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
                Employee e = GetEmployee(emp.Id);
                if (emp != null)
                {
                    e.Name = emp.Name;
                    e.StartDate = emp.StartDate;
                    GuardarCambios();
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
            //List<Employee> empleados = new List<Employee>();   
            //try
            //{
            //    empleados = db.Employee.ToList();
            //    return empleados;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            List<Employee> empleados = new List<Employee>();
            try
            {
                var emps = ObtenerTodos();
                foreach (var e in emps)
                {
                    empleados.Add(e);
                }
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
            /*Employee emp = null;
            
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
            }*/

            try
            {
                Employee emp = ObtenerPorId(id);
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
            //List<Employee> empleados = new List<Employee>();   
            //try
            //{
            //    empleados =  db.Employee
            //        .Where(w => w.Name == searchTerm).ToList();
            //    return empleados;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            List<Employee> empleados = new List<Employee>();   
            try
            {
                var list = ObtenerTodos();
                foreach (var e in list)
                {
                    if (e.Name == searchTerm)
                    {
                        empleados.Add(e);
                    }
                }
                return empleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
