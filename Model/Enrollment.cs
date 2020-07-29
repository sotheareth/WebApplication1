using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public enum Grade
    {
        A, B, C, D, F
    }

    [Table(name: "Enrollment")]
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }


        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
