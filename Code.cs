using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Passwort-Generator ---");
            Console.WriteLine("1. Einfaches Passwort generieren");
            Console.WriteLine("2. Programm beenden");
            Console.Write("Wähle eine Option (1-2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string password = GenerateSimplePassword(8); // Feste Länge von 8 Zeichen
                    Console.WriteLine($"Generiertes Passwort: {password}");
                    break;
                case "2":
                    Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle eine gültige Option.");
                    break;
            }
        }
    }

    static string GenerateSimplePassword(int length)
    {
        const string characters = "abcdefghijklmnopqrstuvwxyz";
        Random random = new Random();
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            char randomChar = characters[random.Next(characters.Length)];
            password.Append(randomChar);
        }

        return password.ToString();
    }
}
