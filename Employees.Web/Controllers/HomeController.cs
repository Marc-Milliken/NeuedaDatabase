using Employees.Data;
using EmployeeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees.Web.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EmployeeRoleCount> data = from employee in db.Employees
                                                 group employee by employee.JobRole into jobGroup
                                                 select new EmployeeRoleCount()
                                                 {
                                                     JobRole = jobGroup.Key,
                                                     EmployeeCount = jobGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}