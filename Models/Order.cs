using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        //Relationships
        public List<OrderItem> OrderItems { get; set; }
    }
}
