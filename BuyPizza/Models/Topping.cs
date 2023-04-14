using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPizza.Models
{
    public class Topping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ToppingID { get; set; }
        [Required]
        [MaxLength(255)]
        public String Name { get; set; }
        [Required]
        public String Image { get; set; }
        [Required]
        public Decimal Rate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ItemTopping> ItemToppings { get; set; }
        public virtual ICollection<OrderItemTopping> OrderItemToppings { get; set; }
    }
}
