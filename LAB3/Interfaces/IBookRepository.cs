namespace bookshop;

public interface IBookRepository {
    public Task AddBook(Book book);
    public List<Book> GetAllBooks();
    public Task<Book?> FindBookByTitle(string title);
    public Task<Book?> FindBookByAuthorName(string author);
    public Task<Book?> FindBookByISBN(string ISBN);
    public Task<Book?> FindBookByRegex(string regex);
}