using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class PeopleEditModel
    {
        public int Id { get; set; }
        [Display(Name = "Цяло име:")]
        public string FullName { get; set; }
        [Display(Name = "Графа:")]
        public string Status { get; set; }
        [Display(Name = "Сума:")]
        public decimal Sum { get; set; }
    }
}
