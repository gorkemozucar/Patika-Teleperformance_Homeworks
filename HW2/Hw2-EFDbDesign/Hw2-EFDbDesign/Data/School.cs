using System.ComponentModel.DataAnnotations;

namespace Hw2_EFDbDesign.Data
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
    }
}
