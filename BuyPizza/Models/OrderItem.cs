using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPizza.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderItemID { get; set; }
        [Required]
        [ForeignKey("Item")]
        public long ItemID { get; set; }
        [Required]
        [ForeignKey("Order")]
        public long OrderID { get; set; }
        [Required]
        public int Quentity { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<OrderItemTopping> OrderItemToppings { get; set; }
    }
}
