using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAll();
        IQueryable<Employee> GetByCountry(string countryName);
    }
}
