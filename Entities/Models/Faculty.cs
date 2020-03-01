using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Faculty
    {
        public int Id { get; set; }
        public string NameOfFaculty { get; set; }
        // [ForeignKey("FacultyId")]
        // public ICollection<Department> Department { get; set; }
    }
}