using PayRoll.Models;
using PayRoll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PayRoll.Controllers
{
    public class HomeController : Controller
    {
        private ICompanyService _companyService;
        private IEmployeeService _employeeService;
        public HomeController(/*ICompanyService companyService, IEmployeeService employeeService*/)
        {
            _companyService = new CompanyService();
            _employeeService = new EmployeeService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListAllCompanies(int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                int pageSize = 2;
                int pageNumber = page ?? 1;

                return View(_companyService.GetAll().OrderBy(x => x.ID).ToPagedList(pageNumber, pageSize));
            }
            throw new Exception("User not authenticated");
        }

        public ActionResult CompanyDetails(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id < 1)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var company = _companyService.GetById(id);


                if (company == null)
                {
                    return HttpNotFound();
                }

                return View(company);
            }
            throw new Exception("User not authenticated");
        }

        [HttpGet]
        public ActionResult ListAllEmployees(int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                int pageSize = 2;
                int pageNumber = page ?? 1;

                return View(_employeeService.GetAll().ToPagedList(pageNumber, pageSize));
            }
            throw new Exception("User not authenticated");
        }

        [HttpGet]
        public ActionResult ListSouthAfricanEmployees(int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                int pageSize = 2;
                int pageNumber = page ?? 1;
                string countryName = "South Africa";

                return View(_employeeService.GetByCountry(countryName).ToPagedList(pageNumber, pageSize));
            }
            throw new Exception("User not authenticated");
        }

    }
}