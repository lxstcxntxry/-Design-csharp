namespace bookshop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class BookCollection : IBookRepository //https://habr.com/ru/articles/248505
{

    private static readonly List<Book> _books = new List<Book>();
    private static string? _loadingFile; // ? for types which may be null

    public void InitCollection(string fileName)
    {
        if (fileName != null && _loadingFile == null)
        {
            string json = File.ReadAllText(fileName);
            _loadingFile = fileName;
            _books.AddRange(JsonSerializer.Deserialize<List<Book>>(json));
        }
    }

    public void AddBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book), "Book cannot be null");
        }
        // if-else sugar
        book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
        _books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return new List<Book>(_books);
    }

    public Book FindBookByTitle(string title)
    {
        Book? foundBook = _books.Find(b => b.Title == title); 
        return foundBook; // Book? can be null
    }

    public Book FindBookByAuthorName(string author)
    {
        Book? foundBook = _books.Find(b => b.Author == author); 
        return foundBook; 
    }

    public Book FindBookByISBN(string ISBN)
    {
        Book? foundBook = _books.Find(b => b.ISBN == ISBN); 
        return foundBook; 
    }

    public Book FindBookByRegex(string regex)
    {
        var expression = new Regex(regex);
        Book? foundBook = _books.Find(b => expression.IsMatch(b.ToString())); 
        return foundBook; 
    }

    public async Task SaveAllAsync() // multithreading
	{
        await using FileStream createStream = File.Create(_loadingFile); 
        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
        await JsonSerializer.SerializeAsync(createStream, _books);
    }
}
