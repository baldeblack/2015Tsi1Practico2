using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RespositoryEF;
using Shared.Entities;
using RepositoryEmployee;

namespace PresentationLayerMvc.Controllers
{
    public class EmployeeController : Controller
    {
        //private Contexto db = new Contexto();
        private IEmployeeRepository repositorio;

        // GET: Employee
        public ActionResult Index()
        {
            repositorio = new EmployeeRepository();
            var empleados = repositorio.GetAllEmployees();
            /*
            var emp = new List<PartTimeEmployee>();

            foreach (var item in empleados)
	        {
		        if (item is PartTimeEmployee)
	            {

                    emp.Add((PartTimeEmployee)item);
	            }
	        }
            */
            return View(empleados);
        }

        // GET: PartTimeEmployees/Details/5
        public ActionResult Details(int id)
        {
            repositorio = new EmployeeRepository();

            var empleado = repositorio.GetEmployee(id);
            Employee emp = (Employee)empleado;
            if (emp is PartTimeEmployee)
            {
                PartTimeEmployee partTimeEmployee = (PartTimeEmployee)empleado;
                if (partTimeEmployee == null)
                {
                    return HttpNotFound();
                }
                return View(partTimeEmployee);
            }
            else 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: FullTimeEmployees/Details/5
        public ActionResult DetailsFull(int id)
        {
            repositorio = new EmployeeRepository();

            var empleado = repositorio.GetEmployee(id);
            Employee emp = (Employee)empleado;
            if (emp is FullTimeEmployee)
            {
                FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)empleado;
                if (fullTimeEmployee == null)
                {
                    return HttpNotFound();
                }
                return View(fullTimeEmployee);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: PartTimeEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: FullTimeEmployees/Create
        public ActionResult CreateFull()
        {
            return View();
        }

        // POST: PartTimeEmployees/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,HourlyRate")] PartTimeEmployee partTimeEmployee)
        {
            if (ModelState.IsValid)
            {
                repositorio = new EmployeeRepository();
                repositorio.AddEmployee(partTimeEmployee);

                return RedirectToAction("Index");
            }

            return View(partTimeEmployee);
        }

        // POST: FullTimeEmployees/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFull([Bind(Include = "Id,Name,StartDate,Salary")] FullTimeEmployee fullTimeEmployee)
        {
            if (ModelState.IsValid)
            {
                repositorio = new EmployeeRepository();
                repositorio.AddEmployee(fullTimeEmployee);

                return RedirectToAction("Index");
            }

            return View(fullTimeEmployee);
        }

        // GET: PartTimeEmployees/Edit/5
        public ActionResult Edit(int id)
        {
            repositorio = new EmployeeRepository();

            var empleado = repositorio.GetEmployee(id);
            Employee emp = (Employee)empleado;
            if (emp is PartTimeEmployee)
            {
                PartTimeEmployee partTimeEmployee = (PartTimeEmployee)empleado;
                if (partTimeEmployee == null)
                {
                    return HttpNotFound();
                }
                return View(partTimeEmployee);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }

        // GET: FullTimeEmployees/Edit/5
        public ActionResult EditFull(int id)
        {
            repositorio = new EmployeeRepository();

            var empleado = repositorio.GetEmployee(id);
            Employee emp = (Employee)empleado;
            if (emp is FullTimeEmployee)
            {
                FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)empleado;
                if (fullTimeEmployee == null)
                {
                    return HttpNotFound();
                }
                return View(fullTimeEmployee);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // POST: PartTimeEmployees/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,HourlyRate")] PartTimeEmployee partTimeEmployee)
        {

            repositorio = new EmployeeRepository();

            if (ModelState.IsValid)
            {
                Employee emp = (Employee)partTimeEmployee;
                repositorio.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(partTimeEmployee);
        }

        // POST: PartTimeEmployees/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFull([Bind(Include = "Id,Name,StartDate,Salary")] FullTimeEmployee  fullTimeEmployee)
        {

            repositorio = new EmployeeRepository();

            if (ModelState.IsValid)
            {
                Employee emp = (Employee)fullTimeEmployee;
                repositorio.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(fullTimeEmployee);
        }

        // GET: PartTimeEmployees/Delete/5
        public ActionResult Delete(int id)
        {
            repositorio = new EmployeeRepository();

            PartTimeEmployee partTimeEmployee = (PartTimeEmployee)repositorio.GetEmployee(id);
            if (partTimeEmployee == null)
            {
                return HttpNotFound();
            }
            return View(partTimeEmployee);
        }

        // GET: FullTimeEmployees/Delete/5
        public ActionResult DeleteFull(int id)
        {
            repositorio = new EmployeeRepository();

            FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)repositorio.GetEmployee(id);
            if (fullTimeEmployee == null)
            {
                return HttpNotFound();
            }
            return View(fullTimeEmployee);
        }

        // POST: PartTimeEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorio = new EmployeeRepository();
            //PartTimeEmployee partTimeEmployee = (PartTimeEmployee)repositorio.GetEmployee(id);
            repositorio.DeleteEmployee(id);
            return RedirectToAction("Index");
        }



        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
