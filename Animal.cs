using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage ="Name can't be more than 50 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age")]
        [Range(typeof(int), "1", "150", ErrorMessage = "Please enter valid number between 1 - 150")]
        public int? Age { get; set; }
        public string? PhotoUrl { get; set; }
        [Display(Name = "Choose your animal photo")]
        [NotMapped]
        public IFormFile? AnimalPhoto { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(2000, ErrorMessage = "Name can't be more than 2000 characters")]
        public string? Description { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}