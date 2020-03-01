using System.ComponentModel.DataAnnotations;

namespace Entities.DTOModels
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The middle name should have length till 100 charactares")]
        public string NameOfFaculty { get; set; }
    }
}