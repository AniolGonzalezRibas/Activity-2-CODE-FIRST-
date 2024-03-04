using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class Payment
    {
        [Key]
        [ForeignKey("Customer")]
        [Name("customerNumber")]
        public int? CustomerNumber { get; set; }
        [Key]
        [Name("checkNumber")]
        public string? CheckNumber { get; set; }
        [Name("paymentDate")]
        public string? PaymentDate { get; set; }
        [Name("amount")]
        public double? Amount { get; set; }

        [Ignore]
        public Customer? Customer { get; set; }

    }
}
