using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Activity_2__CODE_FIRST_.MODEL
{
    public class ProductLines
    {
        [Key]
        [Name("productLine")]
        public string? ProductLine { get; set; }

        [Name("textDescription")]
        public string? TextDescription { get; set; }

        [Name("htmlDescription")]
        public string? HtmlDescription { get; set; }

        [Name("image")]
        public string? Image { get; set; }

        [Ignore]
        public ICollection<Product>? Products { get; set; }


        public override string ToString()
        {
            return ProductLine;
        }

    }
}
