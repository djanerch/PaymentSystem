using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Status { get; set; }
        public decimal Sum { get; set; }
    }
}
