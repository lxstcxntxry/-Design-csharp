using bookshop;

internal class Program
{
	private static async Task Main(string[] args)
	{
		BookCollection booksCollection = new BookCollection();

		//await Utils.PreWork();

		Console.CancelKeyPress += async delegate
		{
			await ConsoleMenu.ExecuteAsync(MenuOption.Exit);
		};

		while (true)
		{
			//async ?
			//что произойте при переполнении оперативной памяти книгами
			MenuOption.None.PrintAllMenuOptions();
			MenuOption choosedOption = Utils.GetMenuOptionInput();
			await ConsoleMenu.ExecuteAsync(choosedOption);
		}
	}
}