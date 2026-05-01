namespace UniversityWebAPI.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Group> Groups { get; set; }

        public override string ToString() => Name;
    }
}
