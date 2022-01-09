using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Core.Models
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid IdGroup { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public IList<Attribute_Product> Attribute_Products { get; set; }
    }
}
