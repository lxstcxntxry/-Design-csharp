namespace bookshop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    public async Task AddBook(Book book)
    {
        using var context = new AppDbContext();
        context.Books.Add(book);
        context.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        using var context = new AppDbContext();
        return context.Books.ToList();
    }

    public async Task<Book?> FindBookByTitle(string title)
    {
        using var context = new AppDbContext();
        Book? foundBook = context.Books.FirstOrDefault(b => b.Title == title);
        return foundBook;
    }

    public async Task<Book?> FindBookByAuthorName(string author)
    {
        using var context = new AppDbContext();
        Book? foundBook = context.Books.FirstOrDefault(b => b.Author == author);
        return foundBook;
    }

    public async Task<Book?> FindBookByISBN(string ISBN)
    {
        using var context = new AppDbContext();
        Book? foundBook = context.Books.FirstOrDefault(b => b.ISBN == ISBN);
        return foundBook;
    }

    public async Task<Book?> FindBookByRegex(string regex)
    {
        using var context = new AppDbContext();
        Book? foundBook = context.Books.FirstOrDefault(b => b.ISBN.Contains(regex) || b.Title.Contains(regex) || b.Author.Contains(regex) || b.Description.Contains(regex));
        return foundBook;
    }
}
