using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOModels
{
    public class StudentDTO
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "The middle name should have length till 20 charactares")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "The middle name should have length till 20 charactares")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(120, ErrorMessage = "The address should have length till 120 charactares")]
        public string Address { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "The phone should have length till 10 charactares")]
        public string Phone { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "The date should have length till 10 charactares")]
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }
    }
}