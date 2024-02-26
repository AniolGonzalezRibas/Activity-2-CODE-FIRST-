using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Office.OfficeCode))]
        public string OfficeCode { get; set; }
        public Office Office { get; set; }
        [ForeignKey(nameof(Employee.EmployeeNumber))]
        public int ReportsTo { get; set; }
        public string JobTitle { get; set; }
        public Employee ReportedEmployee { get; set; }

    }
}
