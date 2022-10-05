using System.ComponentModel.DataAnnotations;

namespace HynteloCodingChallenge.Models
{
    public class Article
    {
        public Guid? Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Title { get; set; }
        public string? Text { get; set; }
    }
}
