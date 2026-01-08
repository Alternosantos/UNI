public class LoanMenu
{
    private void Header(string title)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine($" {title}");
    Console.WriteLine("========================================\n");
}

private void Pause()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
    private Library _library;

    public LoanMenu(Library library)
    {
        _library = library;
    }

    public void Display()
    {
        while (true)
        {
            Header("Loan Management");

            Console.WriteLine("1. Record Loan");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. List Loans");
            Console.WriteLine("4. Back to Main Menu\n");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RecordLoan();
                    break;
                case "2":
                    ReturnBook();
                    break;
                case "3":
                    ListLoans();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("\nInvalid option.");
                    Pause();
                    break;
            }
        }
    }


    private void RecordLoan()
    {
        Header("Record Loan");

        string memberName;
        do
        {
            Console.Write("Member name: ");
            memberName = Console.ReadLine();
            
        } while (string.IsNullOrWhiteSpace(memberName));

        string bookTitle;
        do{
            Console.Write("Book title: ");
            bookTitle = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(bookTitle));
        

        var book = _library.FindBookByTitle(bookTitle);
        var member = _library.FindeMemberByName(memberName);

        if (book != null && member != null && member.IsActive)
        {
            var loan = new Loan
            {
                Book = book,
                Member = member,
                LoanDate = DateTime.Now
            };

            _library.RecordLoan(loan);
            Console.WriteLine("\nLoan recorded successfully.");
        }
        else
        {
            Console.WriteLine("\nInvalid book or inactive member.");
        }

        Pause();
    }

    private void ReturnBook()
    {
        while (true)
        {
            Header("Return Book");

            string memberName;
            do
            {
                Console.Write("Member name: ");
                memberName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(memberName));

            var loans = _library.GetActiveLoansByMemberName(memberName);

            if (loans.Count == 0)
            {
                Console.WriteLine("\nNo active loans found for this member.");
                Pause();
                continue;
            }

            Console.WriteLine("\nActive Loans:");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < loans.Count; i++)
            {
                Console.WriteLine($"{i + 1,2}. {loans[i].Book.Title}");
            }

            int choice;
            do
            {
                Console.Write("\nSelect book number to return: ");
            }
            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 || choice > loans.Count);

            loans[choice - 1].ReturnDate = DateTime.Now;
            _library.SaveChanges();

            Console.WriteLine("\nBook returned successfully.");
            Pause();
            return;
        }
    }

    private void ListLoans()
    {
        Header("Loans List");

        var loans = _library.FindAllLoans();

        if (loans.Count == 0)
        {
            Console.WriteLine("No loans found.");
            Pause();
            return;
        }

        foreach (var loan in loans)
        {
            Console.WriteLine(
                $"{loan.Book.Title,-25} | " +
                $"{loan.Member.Name,-15} | " +
                $"{loan.LoanDate:dd/MM/yyyy} | " +
                $"{(loan.IsReturned ? "Returned" : "Active")}"
            );
        }

        Pause();
    }

}