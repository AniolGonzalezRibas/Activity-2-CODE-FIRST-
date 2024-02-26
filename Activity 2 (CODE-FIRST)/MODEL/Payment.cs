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
        [ForeignKey(nameof(Customer.CustomerNumber))]
        public int CustomerNumber { get; set; }
        [Key]
        public string CheckNumber { get; set; }
        public string PaymentDate { get; set; }
        public double Amount { get; set; }

        public Customer Customer { get; set; }

    }
}
