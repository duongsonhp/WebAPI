using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class FacultyStudent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FacultyId { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public Faculty Faculty { get; set; }
    }
}
