using System.ComponentModel.DataAnnotations;

namespace Hw2_EFDbDesign.Data
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string LessonName { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
