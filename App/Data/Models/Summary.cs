using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Summary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Status { get; set; }
        public int Year { get; set; }
    }
}
