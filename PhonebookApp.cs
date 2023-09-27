using System;

public class PhonebookApp
{


    public static void Main(String[] args)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            { "Eda", "977838445"},
            { "Ece", "987999798"},
        };
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Welcome to the PhoneBook App!");
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Read the phone book");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update an entry");
            Console.WriteLine("4. Remove an entry");
            Console.WriteLine("5. Exit");
            Console.WriteLine("---------------------------------------------------");

            int selection = Convert.ToInt16(Console.ReadLine());

            if (selection == 5)
            {
                break;
            }

            switch (selection)
            {
                case 1:
                    Console.WriteLine("You have {0} contacts.", dict.Count);
                    Console.WriteLine("↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓");
                    foreach (var kvp in dict)
                    {
                        Console.WriteLine("Name = {0}, Phone = {1}", kvp.Key, kvp.Value);
                    }
                    Console.WriteLine(" ");
                    break;

                case 2:
                    Console.WriteLine("Add the name and phone number separated by space");
                    string[] entry = Console.ReadLine().Split(' ');

                    try
                    {
                        dict.Add(entry[0], entry[1]);
                        Console.WriteLine("Success");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"An entry with the same name ({entry[0]}) has already been added.");
                    }
                    Console.WriteLine(" ");
                    break;

                case 3:
                    Console.WriteLine("Enter the name you're looking for.");
                    string update = Console.ReadLine();

                    if (dict.ContainsKey(update))
                    {
                        Console.WriteLine("Contact exists.");
                        dict.Remove(update);
                        Console.WriteLine("Enter the new name and phone number.");
                        string[] updateName = Console.ReadLine().Split(' ');
                        dict[updateName[0]] = updateName[1];
                        Console.WriteLine("Success");
                    }
                    Console.WriteLine(" ");
                    break;
                case 4:
                    Console.WriteLine("Enter the name you'd like to delete");
                    string delete = Console.ReadLine();
                    if (dict.ContainsKey(delete))
                    {
                        dict.Remove(delete);
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("no such name");
                    }
                    Console.WriteLine(" ");
                    break;
            }
        }
    }
}