using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employees.Data;
using Employees.Entities.Employees;
using PagedList;

namespace Employees.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "Name_desc" : "StartDate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = from s in db.Employees
            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.StartDate);
                    break;
                case "Date_desc":
                    employees = employees.OrderByDescending(s => s.StartDate);
                    break;
                default:  // Name ascending 
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employee/Details/
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        [Authorize(Roles = "Admin, Manager, Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [Authorize(Roles = "Admin, Manager, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,DateOfBirth,Address,PhoneNumber,EmergencyContactName,EmergencyContactPhoneNumber,JobRole,StartDate,PreviousJob,Documentation,UsefulLinks,Image")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                //if (file.ContentLength > 0)
                //{
                //    var fileName = Path.GetFileName(file.FileName);
                //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                //    file.SaveAs(path);
                //    employee.Documentation = path;
                //}

                employee.EmployeeID = Guid.NewGuid();


                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), pic);
                // file is uploaded
                file.SaveAs(path);
                //db.Employees.Add(path);
                //return View((object)path);


                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    // db.Employees.Add(path);
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase file)
        //{

        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //        file.SaveAs(path);
        //    }

        //    return RedirectToAction("Index");
        //}

        // GET: Employee/Edit/
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,DateOfBirth,Address,PhoneNumber,EmergencyContactName,EmergencyContactPhoneNumber,JobRole,StartDate,PreviousJob,Documentation,UsefulLinks,Image")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
