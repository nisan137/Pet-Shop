using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        [Required(ErrorMessage = "Required minimum 1 letter", AllowEmptyStrings =false)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Please write your comment here:")]
        public string? CommentText { get; set; }
    }
}
