using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Core.Models
{
    public class Attribute_Product
    {
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
        public Guid IdAttribute { get; set; }
        public Attribute Attribute { get; set; }
    }
}
