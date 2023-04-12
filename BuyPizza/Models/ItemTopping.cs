using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPizza.Models
{
    public class ItemTopping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemToppingID { get; set; }
        [Required]
        [ForeignKey("Item")]
        public long ItemID { get; set; }
        [Required]
        [ForeignKey("Topping")]
        public long ToppingID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Item Item { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
