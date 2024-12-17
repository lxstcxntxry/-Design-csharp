namespace bookshop;

public static class ConsoleMenu
{
    public static async Task ExecuteAsync(MenuOption menuOption)
    {
        switch (menuOption)
        {
            case MenuOption.Exit:
                await ExitBookShopAsync();
                break;
            case MenuOption.AddBook:
                AddBook();
                break;
            case MenuOption.FindByTitle:
                FindByTitle();
                break;
            case MenuOption.FindByAuthor:
                FindByAuthor();
                break;
            case MenuOption.FindByISBN:
                FindByISBN();
                break;
            case MenuOption.FindByWord:
                FindByWord();
                break;
            case MenuOption.ShowAll:
                ShowAll();
                break;
        }
    }

    private static void AddBook()
    {
        BookCollection bookCollection = new BookCollection();
        Book createdBook = Utils.GetBookFromConsole();
        bookCollection.AddBook(createdBook);
        Console.WriteLine("Added!");
    }

    private static void FindByTitle()
    {
        BookCollection bookCollection = new BookCollection();
        Book foundBook = bookCollection.FindBookByTitle(Utils.getBookTitle());
        CheckFoundBook(foundBook);
    }

    private static void FindByAuthor()
    {
        BookCollection bookCollection = new BookCollection();
        Book foundBook = bookCollection.FindBookByAuthorName(Utils.getBookAuthor().Name);
        CheckFoundBook(foundBook);
    }

    private static void FindByISBN()
    {
        BookCollection bookCollection = new BookCollection();
        Book foundBook = bookCollection.FindBookByISBN(Utils.getBookISBN());
        CheckFoundBook(foundBook);
    }

    private static void FindByWord()
    {
        BookCollection bookCollection = new BookCollection();
        Book foundBook = bookCollection.FindBookByRegex(Utils.GetNotNullStr());
        CheckFoundBook(foundBook);
    }

    private static void CheckFoundBook(Book book)
    {
        if (book != null)
            Console.WriteLine($"Found Book: {book.ToString()}");
        else
            Console.WriteLine("There is no such book");
    }

	//  private static void ExitBookShop()
	//  {
	//      BookCollection bookCollection = new BookCollection();
	//      bookCollection.SaveAllAsync();
	//      Environment.Exit(0);
	//  }
	private static async Task ExitBookShopAsync()
	{
		BookCollection bookCollection = new BookCollection();
		await bookCollection.SaveAllAsync();
		Environment.Exit(0);
	}

	private static void ShowAll()
	{
		BookCollection bookCollection = new BookCollection();
		Console.WriteLine("========= Books ========");
		foreach (Book book in bookCollection.GetAllBooks())
		{
			Console.WriteLine(book.ToString());
			Console.WriteLine("========================");
		}
	}
}

public enum MenuOption : int
{
    [System.ComponentModel.Description("None")]
    None = 0,
    [System.ComponentModel.Description("Exit")]
    Exit = 1,
    [System.ComponentModel.Description("Add Book")]
    AddBook = 2,
    [System.ComponentModel.Description("Find Book By Title")]
    FindByTitle = 3,
    [System.ComponentModel.Description("Find Book By Author Name")]
    FindByAuthor = 4,
    [System.ComponentModel.Description("Find Book By ISBN")]
    FindByISBN = 5,
    [System.ComponentModel.Description("Find Book")]
    FindByWord = 6,
    [System.ComponentModel.Description("Show all books")]
    ShowAll = 7

}

public static class MenuOptionMethods // enum https://stackoverflow.com/questions/5985661
{
	public static void PrintAllMenuOptions(this MenuOption menuOption)
	{
		Console.WriteLine("========= Menu =========");
		foreach (MenuOption option in (MenuOption[])Enum.GetValues(typeof(MenuOption)))
		{
			if (option != MenuOption.None)
				Console.WriteLine($"| {(int)option} {option}");
		}
		Console.WriteLine("========================");
	}
}