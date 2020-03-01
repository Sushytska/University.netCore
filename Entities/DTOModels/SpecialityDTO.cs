using System.ComponentModel.DataAnnotations;

namespace Entities.DTOModels
{
    public class SpecialityDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "The nameOfSpeciality should have length till 70 charactares")]
        public string NameOfSpeciality { get; set; }
        public int DepartmentId { get; set; }
    }
}