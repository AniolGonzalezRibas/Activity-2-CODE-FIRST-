using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string OfficeCode { get; set; }
        public int ReportsTo { get; set; }
        public string JobTitle { get; set; }
    }
}
