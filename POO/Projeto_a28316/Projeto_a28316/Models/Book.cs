public class Book
{
    public  int Id { get; set; }
    public  string Title { get; set; }
    public  bool Available { get; set; }
    public  string Author { get; set; }
    public List<Loan> Loans { get; set; } = new();
    

}