using System.ComponentModel.DataAnnotations;

namespace _22023EMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0, 1_00_000)]
        public double Price { get; set; }

        [Required]
        [MaxLength(255)]
        public string Category { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
