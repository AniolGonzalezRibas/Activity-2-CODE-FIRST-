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
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        [Required]
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        [ForeignKey(nameof(Customer.CustomerNumber))]
        public int CustomerNumber { get; set; }
        public Customer Customer { get; set; }
    }
}
