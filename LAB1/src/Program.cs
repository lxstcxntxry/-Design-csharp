using bookshop;

internal class Program
{
	private static async Task<int> Main(string[] args)
	{
		BookCollection booksCollection = new BookCollection(); // https://habr.com/ru/articles/248505/

		await Utils.PreWorkLoad();

		Console.CancelKeyPress += async delegate // https://stackoverflow.com/questions/177856
		{
			await ConsoleMenu.ExecuteAsync(MenuOption.Exit);
		};

		while (true)
		{
			MenuOption.None.PrintAllMenuOptions();
			MenuOption choosedOption = Utils.GetMenuOptionInput();
			await ConsoleMenu.ExecuteAsync(choosedOption);
		}

		
	}
}