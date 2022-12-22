using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Services
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAll();
        Company GetById(int id);
    }
}
