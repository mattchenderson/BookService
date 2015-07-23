
using Microsoft.Azure.Mobile.Server;
namespace BookService.Models
{
    public class BookDetailDTO : EntityData
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }
        public string authorName { get; set; }
        public string genre { get; set; }
    }
}