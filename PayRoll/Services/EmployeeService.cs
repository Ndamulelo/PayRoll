using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayRoll.Models;
using System.Data.Entity;

namespace PayRoll.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _applicationDbContext;

        public EmployeeService()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        public IQueryable<Employee> GetAll()
        {
           return _applicationDbContext.Employees.Include(a => a.HomeAddress).OrderBy(o => o.ID);
        }

        public IQueryable<Employee> GetByCountry(string countryName)
        {
            return _applicationDbContext.Employees.Include(a => a.HomeAddress).OrderBy(o => o.ID).Where(c => c.HomeAddress.Country.Contains(countryName));
        }
    }
}