using System.ComponentModel.DataAnnotations.Schema;

namespace AcebookApi.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Message { get; set; }
        [ForeignKey("User")]
        public long UsersId {get; set;}
        public virtual User User { get; set; }
    }
}