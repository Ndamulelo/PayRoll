using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Position { get; set; }

        public Address HomeAddress { get; set; }
        public int? HomeAddressID { get; set; }

        public Company Company { get; set; }
        public int? CompanyID { get; set; }
    }
}