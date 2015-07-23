
namespace BookService.Models
{
    public class BookDetailDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }
        public string authorName { get; set; }
        public string genre { get; set; }
    }
}