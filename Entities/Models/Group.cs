using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Group
    {
        public int Id { get; set; }
        public string NameOfGroup { get; set; }
        public int SpecialityId { get; set; }
        // [ForeignKey("GroupId")]
        // public ICollection<Student> Student { get; set; }
    }
}