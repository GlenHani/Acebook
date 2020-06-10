using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcebookApi.Models
{
    public class Post
    {
        [Key]
        public long Id { get; set; }
        public string Message { get; set; }

        [ForeignKey("User")]
        public long UserId {get; set;}

        public virtual User User { get; set; }
        
    }
}