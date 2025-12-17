using System.ComponentModel.DataAnnotations;

namespace LAB13_TASK1.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        public string? BookTitle { get; set; }

    }
}
