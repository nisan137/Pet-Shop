using System.ComponentModel.DataAnnotations;

namespace PetShopApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "You must select a category")]
        public string? Name { get; set; }
    }
}
