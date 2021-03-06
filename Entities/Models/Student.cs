using System;

namespace Entities.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }
    }
}