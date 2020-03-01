using System.ComponentModel.DataAnnotations;

namespace Entities.DTOModels
{
    public class GroupDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The nameOfGroup should have length till 30 charactares")]
        public string NameOfGroup { get; set; }
        public int SpecialityId { get; set; }
    }
}