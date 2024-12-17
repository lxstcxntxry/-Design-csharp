using System.Text.RegularExpressions;

namespace bookshop;
public static class Utils
{
    public static int GetNumericInput()
    {
        while (true)
        {
            try
            {
                int number = 0;
                number = int.Parse(Console.ReadLine());
                return number;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("It is not a number...");
            }
        }
    }

    public static string GetNotNullStr()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    public static MenuOption GetMenuOptionInput()
    {
        while (true)
        {
            int number = GetNumericInput();
            if (Enum.IsDefined(typeof(MenuOption), number))
            {
                return (MenuOption)number;
            }
            else
            {
                Console.WriteLine("Invalid menu option. Please select a valid option.");
            }
        }
    }

    public static Book GetBookFromConsole()
    {
        string title = getBookTitle();
        Author author = getBookAuthor();
        Console.WriteLine("What is genre?");
        Genre genre = GetGenreInput();
        string ISBN = getBookISBN();
        Console.WriteLine("Description?");
        string description = GetNotNullStr();

        Book book = new Book(title, author, genre, ISBN, description);
        return book;
    }

    public static string getBookTitle()
    {
        Console.WriteLine("What is the title?");
        string title = GetNotNullStr();
        return title;
    }

    public static Author getBookAuthor()
    {
        Console.WriteLine("Who is author?");
        Author author = new Author(GetNotNullStr());
        return author;
    }

    public static string getBookISBN()
    {
        Console.WriteLine("What is ISBN?");
        string ISBN = GetISBNInput();
        return ISBN;
    }

    private static Genre GetGenreInput()
    {
        GenreMethods.PrintAllGenres(Genre.None);
        while (true)
        {
            int number = GetNumericInput();
            if (Enum.IsDefined(typeof(Genre), number))
            {
                return (Genre)number;
            }
            else
            {
                Console.WriteLine("Invalid genre. Please select a valid genre:");
                GenreMethods.PrintAllGenres(Genre.None);
            }
        }
    }

    private static string GetISBNInput()
    {
        Console.WriteLine("ISBN format: XXX-X-XX-XXXXXX-X (3-1-2-6-1)");
        var regex = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");
        while (true)
        {
            string input = Console.ReadLine();
            if (regex.IsMatch(input))
            {
                BookRepository bookCollection = new BookRepository();
                if (bookCollection.FindBookByISBN(input) == null)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("ISBN must be unique.");
                    Console.WriteLine("ISBN format: XXX-X-XX-XXXXXX-X (3-1-2-6-1)");
                }
            }
            else
            {
                Console.WriteLine("Invalid ISBN.");
                Console.WriteLine("ISBN format: XXX-X-XX-XXXXXX-X (3-1-2-6-1)");
            }
        }
    }

    // public static void PreWork()
    // {
    //     BookCollection booksCollection = new BookCollection();
    //     while (true)
    //     {
    //         Console.WriteLine("Where is books storage?");
    //         string fileName = GetNotNullStr();
    //         try
    //         {
    //             booksCollection.InitCollection(fileName);
    //             return;
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine("There is no such file.");
    //         }
    //     }
    // }
}