using CsvHelper.Configuration.Attributes;
using System;
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
        [Name("customerNumber")]
        public int? CustomerNumber { get; set; }
        [Name("customerName")]
        public string? CustomerName { get; set; }
        [Name("contactLastName")]
        public string? ContactLastName {  get; set; }
        [Name("contactFirstName")]
        public string? ContactFirstName { get; set; }
        [Name("phone")]
        public string? Phone {  get; set; }
        [Name("addressLine1")]
        public string? AdressLine1 { get; set; }
        [Name("addressLine2")]
        public string? AdressLine2 { get; set; }
        [Name("city")]
        public string? City { get; set; }
        [Name("state")]
        public string? State { get; set; }
        [Name("postalCode")]
        public string? PostalCode { get; set; }
        [Name("country")]
        public string? Country { get; set; }
        [ForeignKey("Employee")]
        [Name("salesRepEmployeeNumber")]
        public int? SalesRepEmployeeNumber { get; set; }   
        [Name("creditLimit")]
        public double? CreditLimit { get; set; }

        [Ignore]
        public Employee? Employee { get; set; }
        [Ignore]
        public ICollection<Payment>? Payments { get; set; }
        [Ignore]
        public ICollection<Order>? Orders { get; set; }
        //[Ignore]
        //public ICollection<SpecialPriceList> SpecialPriceLists { get; set; }


        public override string ToString()
        {
            return CustomerNumber.ToString();
        }
    }
}
