using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class SpecialPriceList
    {
        [Key]
        public int SpecialPriceListId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public double Price { get; set; }


        [Ignore]
        public Customer Customer { get; set; }
        [Ignore]
        public Product Product { get; set; }

    }

}
