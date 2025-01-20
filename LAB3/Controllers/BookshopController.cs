using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
    [ApiController]
    [Route("api/bookshop")]
    public class BookshopController : ControllerBase
    {
        private readonly BookRepository bookCollection;

        public BookshopController(BookRepository bookCollection)
        {
            this.bookCollection = bookCollection;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            List<Book> books = bookCollection.GetAllBooks();
            return books != null ? Ok(books) : NoContent();
        }

        [HttpPost("send_one")]
        public IActionResult SendOne([FromBody] Book book)
        {
            _ = bookCollection.AddBook(book);
            List<Book> books = bookCollection.GetAllBooks();
            return books != null ? Ok(books) : NoContent();
        }

        [HttpPost("find_by_title/{title}")]
        public IActionResult FindByTitle(String title)
        {
            Book? book = bookCollection.FindBookByTitle(title).Result;
            return book != null ? Ok(book) : NoContent();
        }

        [HttpPost("find_by_author/{author}")]
        public IActionResult FindByAuthor(String author)
        {
            Book? book = bookCollection.FindBookByAuthorName(author).Result;
            return book != null ? Ok(book) : NoContent();
        }

        [HttpPost("find_by_ISBN/{ISBN}")]
        public IActionResult FindByISBN(String ISBN)
        {
            Book? book = bookCollection.FindBookByISBN(ISBN).Result;
            return book != null ? Ok(book) : NoContent();
        }

        [HttpPost("find_by_regex/{regex}")]
        public IActionResult FindByRegex(String regex)
        {
            Book? book = bookCollection.FindBookByRegex(regex).Result;
            return book != null ? Ok(book) : NoContent();
        }
    }
}
