using System.ComponentModel.DataAnnotations;

namespace HotelServeDLL.Models
{
    public class TableTap
    {
        [Key]
        public int TableID { get; set; }
        public string QRCode { get; set; }
    }
}
