namespace CoursesWorkshop.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set;}
        public virtual Student Student { get;set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
