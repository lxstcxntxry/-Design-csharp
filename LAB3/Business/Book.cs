namespace bookshop;
public class Book : IBook
{
    private int _id;
    private string _title;
    private Author _author;
    private string _description;
    private Genre _genre;
    private string _isbn;
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Author
    {
        get { return _author.Name; }
        set { _author = new Author(value); }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public Genre Genre
    {
        get { return _genre; }
        set { _genre = value; }
    }
    public string ISBN
    {
        get { return _isbn; }
        set { _isbn = value; }
    }

    public Book()
    {
        _id = 0;
        _title = string.Empty;
        _author = new Author(string.Empty);
        _description = string.Empty;
        _genre = Genre.None;
        _isbn = string.Empty;
    }

    public Book(string title, Author author)
    {
        _title = title;
        _author = author;
    }

    public Book(string title, string author)
    {
        _title = title;
        _author = new Author(author);
    }

    public Book(string title, Author author, Genre genre, string ISBN, string description)
    {
        _title = title;
        _author = author;
        _genre = genre;
        _description = description;
        _isbn = ISBN;
    }

    public override string ToString()
    {
        string formatted = $"Title: {_title}\nAuthor: {_author}\nGenre: {_genre}\nDescription: {_description}\nISBN: {_isbn}";
        return formatted;
    }
}

public enum Genre
{
    None,
    Fiction,
    NonFiction,
    Mystery,
    Fantasy,
    Romance
}

public static class GenreMethods
{
    public static void PrintAllGenres(this Genre genre)
    {
        Console.WriteLine("--------- Genres ---------");
        foreach (Genre option in (Genre[])Enum.GetValues(typeof(Genre)))
        {
            if (option != Genre.None)
                Console.WriteLine($"| {(int)option} {option}");
        }
        Console.WriteLine("--------------------------");
    }
}
