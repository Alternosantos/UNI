using Projeto_a28316.DB;
using Projeto_a28316.UI;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new LibraryDbContext())
        {
            context.Database.EnsureCreated();
        }

        var library = new Library();
        var menu = new MainMenu(library);
        menu.Display();
    }
}
