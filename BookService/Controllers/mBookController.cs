using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BookService.Models;
using System;

namespace BookService.Controllers
{
    public class mBookController : TableController<BookDTO>
    {

        private BookServiceContext db = new BookServiceContext();

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BookServiceContext context = new BookServiceContext();
            DomainManager = new EntityDomainManager<BookDTO>(context, Request); //TODO MappedEDM
        }

        // GET tables/mBook
        public IQueryable<BookDTO> GetAllBookDTO()
        {
            //return new BooksController().GetBooks();          
            var books = from b in db.Books
                        select new BookDTO()
                        {
                            id = b.Id,
                            title = b.Title,
                            authorName = b.Author.Name
                        };

            return books;
        }

        // GET tables/mBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<BookDTO> GetBookDTO(string id)
        {
            return null; // TODO
          //  return new SingleResult<BookDTO>(new BooksController().GetBook(int.Parse(id)));
        }

        // PATCH tables/mBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<BookDTO> PatchBookDTO(string id, Delta<BookDTO> patch)
        {
             return UpdateAsync(id, patch); // todo
        }

        // POST tables/mBook
        public async Task<IHttpActionResult> PostBookDTO(BookDTO item) //this type is a pain to convert back to a Book
        {
            BookServiceContext db = new BookServiceContext();
            int AuthorId = db.Authors.Where(a => a.Name == item.authorName).Select(a => a.Id).FirstOrDefault();
            return await (new BooksController()).PostBook(new Book()
            {
                Id = item.id
            });    
        }

        // DELETE tables/mBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBookDTO(string id)
        {
            return new BooksController().DeleteBook(int.Parse(id));  
        }

    }
}