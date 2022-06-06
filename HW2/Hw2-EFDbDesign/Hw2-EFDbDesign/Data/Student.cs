using System.ComponentModel.DataAnnotations;

namespace Hw2_EFDbDesign.Data
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual School School { get; set; }
        public virtual Classroom Classroom { get; set; }

    }
}
