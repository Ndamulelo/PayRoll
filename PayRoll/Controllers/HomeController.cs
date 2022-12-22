using PayRoll.Models;
using PayRoll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PayRoll.Utils;

namespace PayRoll.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICompanyService _companyService;
        private IEmployeeService _employeeService;
     
        public HomeController()
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
            return View(_companyService.GetAll().OrderBy(x => x.ID).ToPagedList(page ?? 1, Util.PageSize));
        }

        public ActionResult CompanyDetails(int id)
        {
            var company = _companyService.GetById(id);


            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        [HttpGet]
        public ActionResult ListAllEmployees(int? page)
        {
            return View(_employeeService.GetAll().ToPagedList(page ?? 1, Util.PageSize));
        }

        [HttpGet]
        public ActionResult ListSouthAfricanEmployees(int? page)
        {
            string countryName = "South Africa";

            return View(_employeeService.GetByCountry(countryName).ToPagedList(page ?? 1, Util.PageSize));
        }

    }
}