using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class PeopleInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името не е попълнено")]
        [Display(Name = "Цяло име:")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Графата не е попълнена")]
        [Display(Name = "Графа:")]
        public string Status { get; set; }
    }
}
