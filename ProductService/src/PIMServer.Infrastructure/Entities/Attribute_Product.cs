using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Entities
{
    public class Attribute_Product
    {
        public Guid IdProduct { get; set; }
        [ForeignKey("Id")]
        public virtual Product Product { get; set; }
        public Guid IdAttribute { get; set; }
        [ForeignKey("Id")]
        public virtual Attribute Attribute { get; set; }

    }
}
