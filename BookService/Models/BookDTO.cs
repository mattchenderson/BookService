
using Microsoft.Azure.Mobile.Server;
namespace BookService.Models
{
    public class BookDTO : EntityData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
    }
}