using System.ComponentModel.DataAnnotations;

namespace Base.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int Roll { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Classes Classes { get; set; }
        public int ClassesId { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
