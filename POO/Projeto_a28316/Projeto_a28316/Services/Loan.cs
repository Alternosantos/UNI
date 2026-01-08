public class Loan
{
    public int Id { get; set; }
    public Book Book { get; set; } = null!;
    public Member Member { get; set; } = null!;
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned => ReturnDate.HasValue;
}