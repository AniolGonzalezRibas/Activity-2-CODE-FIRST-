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
    public class Order
    {
        [Key]
        [Name("orderNumber")]
        public int OrderNumber { get; set; }
        [Column(TypeName = "date")]
        [Name("orderDate")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [Name("requiredDate")]
        public DateTime RequiredDate { get; set; }
        [Column(TypeName = "date")]
        [Name("shippedDate")]
        public DateTime ShippedDate { get; set; }
        [Name("status")]
        public string Status { get; set; }
        [Name("comments")]
        public string Comments { get; set; }
        [ForeignKey(nameof(Customer.CustomerNumber))]
        [Name("customerNumber")]
        public int CustomerNumber { get; set; }
        [Ignore]
        public Customer Customer { get; set; }
    }
}
