namespace bookshop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
	
    private readonly AppDbContext? context;

	public async Task AddBookAsync(Book book)
	{
		if (book == null)
			throw new ArgumentNullException(nameof(book));

		_ = context.Books.Add(book);
		await context.SaveChangesAsync();
	}

	public List<Book> GetAllBooks()
    {
        using var context = new AppDbContext();
        return context.Books.ToList(); 
    }

	//public Book FindBookByTitle(string title)
	//{
	//    using var context = new AppDbContext();
	//    var books = context.Books.ToList();
	//    Book? foundBook = books.Find(b => b.Title == title);
	//    return foundBook;
	//}

	public async Task<Book?> FindBookByTitleAsync(string title)
	{
		using var context = new AppDbContext();
		return await context.Books.FirstOrDefaultAsync(b => b.Title == title);
	}

	//public Book FindBookByAuthorName(string author)
	//{
	//   using var context = new AppDbContext();
	//   var books = context.Books.ToList();
	//   Book? foundBook = books.Find(b => b.Author == author);
	//   return foundBook;
	//}

	public async Task<Book?> FindBookByAuthorNameAsync(string author)
	{
		using var context = new AppDbContext();
		return await context.Books.FirstOrDefaultAsync(b => b.Author == author);
	}

	//public Book FindBookByISBN(string ISBN)
	//{
	//   using var context = new AppDbContext();
	//   var books = context.Books.ToList();
	//   Book? foundBook = books.Find(b => b.ISBN == ISBN);
	//   return foundBook;
	//}

	public async Task<Book?> FindBookByISBNAsync(string isbn)
	{
		using var context = new AppDbContext();
		return await context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
	}

	//public Book FindBookByRegex(string regex)
	//   {
	//       var expression = new Regex(regex);
	//       using var context = new AppDbContext();
	//       var books = context.Books.ToList();
	//       Book? foundBook = books.Find(b => expression.IsMatch(b.ToString()));
	//       return foundBook;
	//   }

	public async Task<Book?> FindBookByRegexAsync(string regex)
	{
		var expression = new Regex(regex);
		using var context = new AppDbContext();

		// Применяем регулярное выражение к полю Title (название книги)
		Book? foundBook = await context.Books.FirstOrDefaultAsync(b => expression.IsMatch(b.Title));

		return foundBook;
	}
}
