using bookshop;

public interface IBook
{
    string Title { set; get; }
    string Description { set; get; }
    string Author { set; get; }
    Genre Genre { set; get; }
    string ISBN { set; get; }
}