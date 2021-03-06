using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cedro_restaurant_back_end.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}