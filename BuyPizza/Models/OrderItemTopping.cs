using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPizza.Models
{
    public class OrderItemTopping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderItemToppingID { get; set; }
        [Required]
        [ForeignKey("OrderItem")]
        public long OrderItemID { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
