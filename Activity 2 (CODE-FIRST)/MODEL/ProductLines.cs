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
        public string ProductLine { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public string Image { get; set; }

    }
}
