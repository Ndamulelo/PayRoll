using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayRoll.Models;
using System.Data.Entity;

namespace PayRoll.Services
{
    public class CompanyService : ICompanyService
    {
        private ApplicationDbContext _applicationDbContext;
        
        public CompanyService()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        public string CompanyName()
        {
            return "Muthaphuli Holdings";
        }

        public IQueryable<Company> GetAll()
        {
            return _applicationDbContext.Companies;
        }

        public Company GetById(int id)
        {
            return _applicationDbContext.Companies.Where(x => x.ID == id).Include(b => b.BusinessAddress).FirstOrDefault();
        }
    }
}