using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIMServer.Infrastructure.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("Id")]
        public Guid IdCategory { get; set; }
        public Category Category { get; set; }
        public IList<Attribute_Product> Attribute_Products { get; set; }
    }
}