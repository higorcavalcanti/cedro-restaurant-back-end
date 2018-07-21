using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cedro_restaurant_back_end.Models
{
    [Table("Dishes")]
    public class Dish
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public double Price { get; set; }
        
        [Required]
        public long RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}