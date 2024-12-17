namespace bookshop;

public interface IBookRepository {
    public Task AddBookAsync(Book book);
    public List<Book?> GetAllBooks();
    public Task<Book?> FindBookByTitleAsync(string title);
    public Task<Book?> FindBookByAuthorNameAsync(string author);
    public Task<Book?> FindBookByISBNAsync(string ISBN);
    public Task<Book?> FindBookByRegexAsync(string regex);
}