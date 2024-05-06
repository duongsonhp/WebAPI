using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BornDate { get; set; }

        public ICollection<FacultyStudent> FacultyStudents { get; set; }
    }
}
