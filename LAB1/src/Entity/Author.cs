namespace bookshop;
public class Author
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public Author(string name)
    {
        _name = name;
    }
}