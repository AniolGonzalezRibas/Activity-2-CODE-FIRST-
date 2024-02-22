using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class OrderDetail
    {
        [Key]
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public double PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
