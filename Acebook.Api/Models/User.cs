using System.ComponentModel.DataAnnotations;

namespace AcebookApi.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string UserName {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string EmailAddress {get; set;}
    }
}