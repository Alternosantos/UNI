public class BookMenu
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

    public BookMenu(Library library)
    {
        _library = library;
    }

    public void Display()
    {
        while (true)
        {
            Header("Book Management");

            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Search Book by Title");
            Console.WriteLine("4. List Books");
            Console.WriteLine("5. Back to Main Menu\n");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    ListBooks();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("\nInvalid option.");
                    Pause();
                    break;
            }
        }
    }


    private void AddBook()
    {
        Header("Add Book");

        string title;
        do
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Please enter a valid title.");
                Pause();
            }
        }
        while (string.IsNullOrWhiteSpace(title));

        string author;
        do
        {
            Console.Write("Author: ");
            author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Author cannot be empty. Please enter a valid author.");
                Pause();
            }
        }
        while (string.IsNullOrWhiteSpace(author));

        var book = new Book
        {
            Title = title,
            Author = author
        };

        _library.AddBook(book);

        Console.WriteLine("\nBook added successfully.");
        Pause();
    }



    private void RemoveBook()
    {
        Header("Remove Book");
        string title;
        do
        {
            Console.Write("Book title: ");
            title = Console.ReadLine();

        }while (string.IsNullOrWhiteSpace(title));

        var book = _library.FindBookByTitle(title);

        if (book != null)
        {
            _library.RemoveBook(book);
            Console.WriteLine("\nBook removed successfully.");
        }
        else
        {
            Console.WriteLine("\nBook not found.");
        }

        Pause();
    }


    private void SearchBook()
    {
        Header("Search Book");
        string title;
        do
        {
            Console.Write("Book title: ");
            title = Console.ReadLine();

        }while (string.IsNullOrWhiteSpace(title));

        var book = _library.FindBookByTitle(title);

        if (book != null)
        {
            Console.WriteLine("\nBook Details");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title : {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
        }
        else
        {
            Console.WriteLine("\nBook not found.");
        }

        Pause();
    }


    private void ListBooks()
    {
        Header("Books in Library");

        var books = _library.FindAllBooks();

        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            Pause();
            return;
        }

        Console.WriteLine($"{"Title",-30} | Author");
        Console.WriteLine(new string('-', 50));

        foreach (var book in books)
        {
            Console.WriteLine(
                $"{book.Title,-30} | {book.Author}"
            );
        }

        Pause();
    }

}