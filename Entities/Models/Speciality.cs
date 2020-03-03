using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Speciality
    {
        public int Id { get; set; }
        public string NameOfSpeciality { get; set; }
        public int DepartmentId { get; set; }
        // [ForeignKey("SpecialityId")]
        // public ICollection<Group> Group { get; set; }
    }
}