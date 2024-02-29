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
    public class Product
    {
        [Key]
        public string ProducCode { get; set; }
        public string ProductCode { get; set; }

        [Name("productName")]
        public string ProductName { get; set; }

        [Name("productLine")]
        [ForeignKey(nameof(ProductLines.ProductLine))]
        public string ProductLine {  get; set; }

        public ProductLines ProductLines { get; set; }

        [Name("productScale")]
        public string ProductScale { get; set; }

        [Name("productVendor")]
        public string ProductVendor { get; set; }

        [Name("productDescription")]
        public string ProductDescription { get; set; }
        [Name("quantityInStock")]
        public short QuantityStock { get; set; }
        [Name("buyPrice")]
        public double BuyPrice { get; set; }

        [Name("MSRP")]
        public double MSRP { get; set; }
    }
}
