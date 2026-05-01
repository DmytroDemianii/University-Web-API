namespace UniversityWebAPI.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public List<Student> Students { get; set; }

        public override string ToString() => Name;
    }
}
