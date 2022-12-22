using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayRoll.Models;

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
            // throw new NotImplementedException();
        }

        public Company GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}