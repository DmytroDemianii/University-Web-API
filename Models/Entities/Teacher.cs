namespace UniversityWebAPI.Models.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Group> Groups { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
