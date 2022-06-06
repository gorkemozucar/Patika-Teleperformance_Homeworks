using System.ComponentModel.DataAnnotations;

namespace HW1.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string? CategoryName { get; set; }


    }
}
