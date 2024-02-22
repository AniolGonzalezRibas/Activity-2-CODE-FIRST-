using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class Product
    {
        [Key]
        public string ProducCode { get; set; }
        public string ProductName { get; set; }
        public string ProductLine {  get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public short QuantityStock { get; set; }
        public double BuyPrice { get; set; }
        public double MSRP { get; set; }
    }
}
