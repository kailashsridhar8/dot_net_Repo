using System.ComponentModel.DataAnnotations;

namespace WebAPIApplication2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
