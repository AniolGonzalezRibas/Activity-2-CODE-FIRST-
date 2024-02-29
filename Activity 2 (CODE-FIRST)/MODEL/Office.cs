using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class Office
    {
        [Key]
        [Name("officeCode")]
        public string OfficeCode { get; set; }
        [Name("city")]
        public string City { get; set; }
        [Name("phone")]
        public string Phone {  get; set; }
        [Name("addressLine1")]
        public string AdressLine1 { get; set; }
        [Name("addressLine2")]
        public string AdressLine2 { get; set; }
        [Name("state")]
        public string State { get; set; }
        [Name("country")]
        public string Country { get; set; }
        [Name("postalCode")]
        public string PostalCode { get; set; }
        [Name("territory")]
        public string Territory { get; set; }
    }
}
