public class Member
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    public int IdNumber { get; set; }
    public List<Loan> Loans { get; set; } = new();
    public bool IsActive { get; set; }  
    
        public void BorrowBook(Book book, DateTime loanDate)
        {
            if (book.Available)
            {
                Loan loan = new Loan
                {
                    Book = book,
                    Member = this,
                    LoanDate = loanDate
                };
                Loans.Add(loan);
                book.Available = false;
            }
        }
        public void ReturnBook(DateTime returnDate)
        {
            if (Loans != null && Loans.Count > 0)
            {
                Loan loan = Loans[0];
                loan.ReturnDate = returnDate;
                loan.Book.Available = true;
                Loans.RemoveAt(0);
            }
        } 
}