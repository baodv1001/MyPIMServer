using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Entities
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdGroup { get; set; }
        [ForeignKey("Id")]
        public AttributeGroup AttributeGroup { get; set; }
        public IList<Attribute_Product> Attribute_Products { get; set; }
    }
}
