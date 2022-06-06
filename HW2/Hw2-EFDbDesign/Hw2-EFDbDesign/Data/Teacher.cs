using System.ComponentModel.DataAnnotations;

namespace Hw2_EFDbDesign.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
