using System.ComponentModel.DataAnnotations;

namespace Tp3EFcoreRelations.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal SingUpFree { get; set; }
        public int DurationInMonth { get; set; }
        public float DiscountRate {  get; set; }
        //Relation One-to-Many avec Customer
        public ICollection<Customer> customer { get; set; } = new List<Customer>();
    }
}
