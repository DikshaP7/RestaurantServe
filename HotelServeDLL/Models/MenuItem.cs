using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelServeDLL.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Precision(18,2)]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
