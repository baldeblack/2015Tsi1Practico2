using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesNativeSQL : IDALEmployees
    {

        static EmployeeDBContext db = new EmployeeDBContext();

        

        public void AddEmployee(Employee nuevoemp)
        {
            try
            {
                string nativeSQLQuery =
                 "INSERT INTO Employees " +
                 "VALUES nuevoemp ";

                var result = db.Employee.SqlQuery(nativeSQLQuery);

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteEmployee(int id)
        {

            try
            {

                string nativeSQLQuery =
                    "SELECT e " +
                    "FROM db.Employees " +
                    "WHERE e.id = '{0}'";

                var emp = db.Employee.SqlQuery(nativeSQLQuery, id);

                foreach (var item in emp)
                {
                    db.Employee.Remove(item);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            try
            {
                
            string nativeSQLQuery =
                "SELECT * " +
                "FROM dbo.Employees ";

            
            var emp = db.Employee.SqlQuery(nativeSQLQuery);

            foreach (var item in emp)
            {
                list.Add(item);
            }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }



        public Employee GetEmployee(int id)
        {
            
            /*try
                {

                    string nativeSQLQuery =
                        "SELECT e " +
                        "FROM db.Employees "+
                        "WHERE e.id = '{0}'";

                    List<Employee> list = new List<Employee>();
                    var lista = db.Employee.SqlQuery(nativeSQLQuery,id).ToList();

                    foreach (var item in lista)
                        {
                            //se quiere retornar 1 y no la lista. corregir
                        return item;   
                        }

                }

            catch (Exception ex)
                {
                    throw ex;
                }
            */
            throw new NotImplementedException();
        }


        public List<Employee> SearchEmployees(string searchTerm)
        {
            try
            {

                string nativeSQLQuery =
                    "SELECT e " +
                    "FROM db.Employees " +
                    "WHERE e.name = '{0}'";

                List<Employee> lista = new List<Employee>();
                var list = db.Employee.SqlQuery(nativeSQLQuery, searchTerm).ToList();

                foreach (var item in list)
                {
                    lista.Add(item);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
