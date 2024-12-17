//using System.Text.Json;

//namespace bookshop;

//public class Tests
//{
//	[Test]
//	public void TestSerialization()
//	{
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		string serializedBook = JsonSerializer.Serialize(book);
//		Book? deserializedBook = JsonSerializer.Deserialize<Book>(serializedBook);
//		bool isEqual = deserializedBook != null &&
//						deserializedBook.Title == book.Title &&
//						deserializedBook.Author == book.Author &&
//						deserializedBook.Genre == book.Genre &&
//						deserializedBook.ISBN == book.ISBN;
//		Assert.True(isEqual);
//	}

//	[Test]
//	public async Task TestAddBook()
//	{
//		BookRepository bookCollection = new BookRepository();
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		await bookCollection.AddBookAsync(book);
//		var collection = bookCollection.GetAllBooks();
//		Assert.True(collection.Last().ISBN == book.ISBN);
//	}

//	[Test]
//	public async Task TestFindByTitleBook()
//	{
//		BookRepository bookCollection = new BookRepository();
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		await bookCollection.AddBookAsync(book);
//		var foundBook = bookCollection.FindBookByTitle("someTitle");
//		Assert.True(foundBook.ISBN == book.ISBN);
//	}

//	[Test]
//	public async Task TestFindByAuthorNameBook()
//	{
//		BookRepository bookCollection = new BookRepository();
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		await bookCollection.AddBookAsync(book);
//		var foundBook = bookCollection.FindBookByAuthorName("someAuthor");
//		Assert.True(foundBook.ISBN == book.ISBN);
//	}

//	[Test]
//	public async Task TestFindByISBNBook()
//	{
//		BookRepository bookCollection = new BookRepository();
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		await bookCollection.AddBookAsync(book);
//		var foundBook = bookCollection.FindBookByISBN("XXX-X-XX-XXXXXX-X");
//		bool isEqual = foundBook != null &&
//						foundBook.Title == book.Title &&
//						foundBook.Author == book.Author &&
//						foundBook.Genre == book.Genre &&
//						foundBook.ISBN == book.ISBN;
//		Assert.True(isEqual);
//	}

//	[Test]
//	public async Task TestFindByRegexBook()
//	{
//		BookRepository bookCollection = new BookRepository();
//		Book book = new Book("someTitle", new Author("someAuthor"), Genre.None, "XXX-X-XX-XXXXXX-X", "someDescription");
//		await bookCollection.AddBookAsync(book);
//		var foundBook = bookCollection.FindBookByRegex("someTitle");
//		Assert.True(foundBook.ISBN == book.ISBN);
//	}
//}