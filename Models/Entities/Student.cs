using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebAPI.Models.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
