using Projeto_a28316.DB;
using Microsoft.EntityFrameworkCore;


public class Library
{
    private readonly LibraryDbContext _context = new();
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Loan> Loans { get; set; } = new List<Loan>();
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }  
        public void RemoveBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        public Book? FindBookByTitle(string title)
        {
            var normalized = title.ToLower();
            return _context.Books
                .FirstOrDefault(b => b.Title.ToLower() == normalized);
        }

        public List<Book> FindAllBooks()
        {
                return _context.Books.ToList();
        }
        public void RegisterMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }
        public void DeactivateUser(Member member)
        {
            member.IsActive = false;
            _context.Members.Update(member);
            _context.SaveChanges(); 
        }
        public Member? FindeMemberByName(string name)
        {
            var normalized = name.ToLower();
            return _context.Members
            .FirstOrDefault(m => m.Name.ToLower() == normalized);
        }
        public List<Member> FindAllMembers()
        {
            return _context.Members.ToList();
        }
        public void RecordLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
        public bool ReturnLoan(Loan loan)
        {
            if (loan == null) return false;

            loan.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        public List<Loan> GetActiveLoansByMemberName(string memberName)
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .Where(l =>
                    l.Member.Name.ToLower() == memberName.ToLower() &&
                    l.ReturnDate == null)
                .ToList();
        }
         public List<Loan> FindAllLoans()
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .ToList();
        }
        public Loan? FindLoanByBookTitle(string title)
        {
            return _context.Loans.FirstOrDefault(l => l.Book.Title.ToLower() == title.ToLower()
         && l.ReturnDate == null);
        } 
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

}

