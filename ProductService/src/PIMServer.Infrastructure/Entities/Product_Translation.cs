using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMServer.Infrastructure.Entities
{
    public class Product_Translation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid IdProduct { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }
        public Guid IdLanguage { get; set; }
        [ForeignKey("Id")]
        public Language Language { get; set; }
    }
}
