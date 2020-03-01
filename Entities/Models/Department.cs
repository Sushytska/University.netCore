using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string NameOfDepartment { get; set; }
        public int FacultyId { get; set; }
        // [ForeignKey("DepartmentId")]
        // public ICollection<Speciality> Speciality { get; set; }
    }
}