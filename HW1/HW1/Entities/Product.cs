using System.ComponentModel.DataAnnotations;

namespace HW1.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
    }
}
