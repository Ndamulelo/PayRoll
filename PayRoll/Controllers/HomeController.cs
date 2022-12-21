using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PayRoll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListAllCompanies()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext db = new ApplicationDbContext();

                return View(db.Companies.ToList());
            }
            throw new Exception("User not authenticated");
        }

        public ActionResult CompanyDetails()
        {
            if (User.Identity.IsAuthenticated)
            {
                int? id = int.Parse( Request.Url.AbsolutePath.Substring(Request.Url.AbsolutePath.LastIndexOf('/')+1));

                ApplicationDbContext db = new ApplicationDbContext();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Company c = null;

                for(int i = 0; i < db.Companies.ToList().Count; i++)
                {
                    var x = db.Companies.ToList()[i];

                    if(x.ID == id)
                    {
                        c = x;
                    }
                }

                if (c == null)
                {
                    return HttpNotFound();
                }
                return View(c);
            }
            throw new Exception("User not authenticated");
        }

        [HttpGet]
        public ActionResult ListAllEmployees()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext db = new ApplicationDbContext();

                return View(db.Employees.ToList());
            }
            throw new Exception("User not authenticated");
        }

        [HttpGet]
        public ActionResult ListSouthAfricanEmployees()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Employee> l = new List<Employee>();

                ApplicationDbContext db = new ApplicationDbContext();

                for(int i = 0; i < db.Employees.ToList().Count; i++)
                {
                    var e = db.Employees.ToList()[i];

                    if (e.HomeAddress?.Country == "South Africa")
                    {
                        l.Add(e);
                    }
                }

                return View(l);
            }
            throw new Exception("User not authenticated");
        }

    }
}