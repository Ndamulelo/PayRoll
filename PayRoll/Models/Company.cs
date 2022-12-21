using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class Company
    {
        public Company()
        {
            Employees = new List<Employee>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }

        public Address BusinessAddress { get; set; }
        public int? BusinessAddressID { get; set; }
    }
}