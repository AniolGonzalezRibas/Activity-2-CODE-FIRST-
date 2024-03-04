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
    public class OrderDetail
    {
        [Key]
        [ForeignKey("Order")]
        [Name("orderNumber")]
        public int? OrderNumber { get; set; }
        [Key]
        [ForeignKey("Product")]
        [Name("productCode")]
        public string? ProductCode { get; set; }
        [Name("quantityOrdered")]
        public int? QuantityOrdered { get; set; }
        [Name("priceEach")]
        public double? PriceEach { get; set; }
        [Name("orderLineNumber")]
        public short? OrderLineNumber { get; set; }

        [Ignore]
        public Product? Product { get; set; }
        [Ignore]
        public Order? Order { get; set; }
    }
}
