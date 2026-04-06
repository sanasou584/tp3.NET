using System.ComponentModel.DataAnnotations;

namespace Tp3EFcoreRelations.Models
{
    public class Genre
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public string Name { get; set; }
        //Relation One-to-Many avec Movie
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
