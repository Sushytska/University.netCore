using System.ComponentModel.DataAnnotations;

namespace Entities.DTOModels
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The middle name should have length till 50 charactares")]
        public string NameOfDepartment { get; set; }
        public int FacultyId { get; set; }

    }
}