using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Faculty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<FacultyStudent> FacultyStudents { get; set; }
    }
}
