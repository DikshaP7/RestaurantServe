using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelServeDLL.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int TableId { get; set; }
        [ForeignKey("TableId")]
        public TableTap Table { get; set; } //Navigation Property
        [Required]
        public string Items { get; set; } // JSON string for ordered items
        [Required]
        [Precision(18,2)]
        public decimal TotalAmount {  get; set; }
        [Required]
        public string Status { get; set; } // Pending, Preparing, Ready, Served
    }
}
