﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string ContactLastName {  get; set; }
        public string ContactFirstName { get; set; }
        public string Phone {  get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        [ForeignKey(nameof(Employee.ReportsTo))]
        public int SalesRepEmployeeNumber { get; set; }
        public Employee Employee { get; set; }
        public double CreditLimit { get; set; }
    }
}
