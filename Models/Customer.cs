using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp3EFcoreRelations.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "le nom du client est obligatoire")]
        [StringLength(100,ErrorMessage ="Le nom ne doit pas depasser 100 caractere")]
        public string Name {  get; set; }
        //Relation Many-to-One avec MembershipType
        [ForeignKey("MembershipType")]
        public int? MembershipTypeID { get; set; }
        public MembershipType? membeshipType { get; set;  }
        //Relation Many-to-Many avec Movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();


    }
}
