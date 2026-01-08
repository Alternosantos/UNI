using Projeto_a28316.DB;
using Projeto_a28316.UI;

namespace Projeto_a28316.UI;

public class MainMenu
{
    private Library _library;

    public MainMenu(Library library)
    {
        _library = library;
    }

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

    public void Display()
    {
        while (true)
        {
            Header("Library Management System");

            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Members");
            Console.WriteLine("3. Manage Loans");
            Console.WriteLine("4. Exit\n");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BookMenu(_library).Display();
                    break;

                case "2":
                    new MemberMenu(_library).Display();
                    break;

                case "3":
                    new LoanMenu(_library).Display();
                    break;

                case "4":
                    Console.WriteLine("\nExiting application...");
                    Pause();
                    return;

                default:
                    Console.WriteLine("\nInvalid option.");
                    Pause();
                    break;
            }
        }
    }
}
