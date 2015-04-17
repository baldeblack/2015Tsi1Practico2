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
    public class PartTimeEmployeesController : Controller
    {
        //private Contexto db = new Contexto();
        private IEmployeeRepository repositorio;

        // GET: PartTimeEmployees
        public ActionResult Index()
        {
            repositorio = new EmployeeRepository();
            var empleados = repositorio.GetAllEmployees();
            /*
            foreach (var item in empleados)
	        {
		        if (item is PartTimeEmployee)
	            {
                    
	            }
	        }*/

            return View(empleados.ToList());
        }

        // GET: PartTimeEmployees/Details/5
        public ActionResult Details(int id)
        {
            repositorio = new EmployeeRepository();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
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

        // GET: PartTimeEmployees/Create
        public ActionResult Create()
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

        // GET: PartTimeEmployees/Edit/5
        public ActionResult Edit(int id)
        {
            repositorio = new EmployeeRepository();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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

        // GET: PartTimeEmployees/Delete/5
        public ActionResult Delete(int id)
        {
            repositorio = new EmployeeRepository();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PartTimeEmployee partTimeEmployee = (PartTimeEmployee)repositorio.GetEmployee(id);
            if (partTimeEmployee == null)
            {
                return HttpNotFound();
            }
            return View(partTimeEmployee);
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
