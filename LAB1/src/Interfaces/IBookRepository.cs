namespace bookshop;

public interface IBookRepository {
    public void AddBook(Book book);
    public List<Book> GetAllBooks();

    public Book FindBookByTitle(string title);
    public Book FindBookByAuthorName(string author);
    public Book FindBookByISBN(string ISBN);
    public Book FindBookByRegex(string regex);
}