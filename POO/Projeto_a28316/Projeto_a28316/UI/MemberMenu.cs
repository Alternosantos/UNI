public class MemberMenu
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

    public MemberMenu(Library library)
    {
        _library = library;
    }

    public void Display()
    {
        while (true)
        {
            Header("Member Management");

            Console.WriteLine("1. Register Member");
            Console.WriteLine("2. Deactivate / Activate Member");
            Console.WriteLine("3. Search Member by ID Number or Name");
            Console.WriteLine("4. List Members");
            Console.WriteLine("5. Back to Main Menu\n");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterMember();
                    break;
                case "2":
                    DeactivateMember();
                    break;
                case "3":
                    SearchMember();
                    break;
                case "4":
                    ListMembers();
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


    private void RegisterMember()
    {
        Header("Register Member");

        string memberName;
        do
        {
            Console.Write("Member name: ");
            memberName = Console.ReadLine();
            
        } while (string.IsNullOrWhiteSpace(memberName));

        var member = new Member
        {
            Name = memberName,
            IdNumber = _library.RandomIdNumber(),
            IsActive = true
        };

        _library.RegisterMember(member);

        Console.WriteLine("\nMember registered successfully.");
        Pause();
    }
    

    private void DeactivateMember()
    {
        Header("Deactivate / Activate Member");
        
        int idnumber;
        do
        {
            Console.Write("Member ID Number: ");
            idnumber = int.Parse(Console.ReadLine());
            
        } while (idnumber <= 0);
    

        var member = _library.FindeMemberByName(idnumber);

        if (member != null && member.IsActive == true)
        {
            _library.DeactivateUser(member);
            Console.WriteLine("\nMember deactivated successfully.");
        }
        else if (member != null && member.IsActive == false)
        {
            _library.ActivateUser(member);
            Console.WriteLine("\nMember Activated successfully.");
        }
        else
        {
            Console.WriteLine("\nMember not found.");
        }

        Pause();
    }


    private void SearchMember()
    {
        Header("Search Member");
        string name;
        do
        {
            Console.Write("Member name: ");
            name = Console.ReadLine();

        } while (string.IsNullOrWhiteSpace(name));

        var member = _library.FindeMemberByName(name);

        if (member != null)
        {
            Console.WriteLine("\nMember Details");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Name   : {member.Name}");
            Console.WriteLine($"Status : {(member.IsActive ? "Active" : "Inactive")}");
        }
        else
        {
            Console.WriteLine("\nMember not found.");
        }

        Pause();
    }

    private void ListMembers()
    {
        Header("Members List");

        var members = _library.FindAllMembers();

        if (members.Count == 0)
        {
            Console.WriteLine("No members registered.");
            Pause();
            return;
        }

        Console.WriteLine($"{"Name",-20} | Status");
        Console.WriteLine(new string('-', 32));

        foreach (var member in members)
        {
            Console.WriteLine(
                $"{member.Name,-20} | " +
                $"{(member.IsActive ? "Active" : "Inactive")}"
            );
        }

        Pause();
    }

}