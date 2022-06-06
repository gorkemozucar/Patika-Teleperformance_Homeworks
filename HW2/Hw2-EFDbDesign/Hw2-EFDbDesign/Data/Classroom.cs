using System.ComponentModel.DataAnnotations;

namespace Hw2_EFDbDesign.Data
{
    public class Classroom
    {
        [Key]
        public int ClassromID { get; set; }
        public string ClassroomName { get; set; }
  
    }
}
