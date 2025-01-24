using System;
using System.Text;
using System.Text.RegularExpressions;

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
            Console.WriteLine("1. Passwort generieren");
            Console.WriteLine("2. Passwortstärke prüfen");
            Console.WriteLine("3. Programm beenden");
            Console.Write("Wähle eine Option (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GeneratePasswordMenu();
                    break;
                case "2":
                    CheckPasswordStrengthMenu();
                    break;
                case "3":
                    Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle eine gültige Option.");
                    break;
            }
        }
    }

    static void GeneratePasswordMenu()
    {
        Console.Write("\nGib die gewünschte Passwortlänge ein (z. B. 12): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int length) && length > 0)
        {
            string password = GeneratePassword(length);
            Console.WriteLine($"Generiertes Passwort: {password}");
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe. Bitte gib eine positive Zahl ein.");
        }
    }

    static string GeneratePassword(int length)
    {
        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{}|;:,.<>?/";

        Random random = new Random();
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            char randomChar = characters[random.Next(characters.Length)];
            password.Append(randomChar);
        }

        return password.ToString();
    }

    static void CheckPasswordStrengthMenu()
    {
        Console.Write("\nGib ein Passwort ein, um die Stärke zu prüfen: ");
        string password = Console.ReadLine();

        string strength = EvaluatePasswordStrength(password);
        Console.WriteLine($"Passwortstärke: {strength}");
    }

    static string EvaluatePasswordStrength(string password)
    {
        if (password.Length < 8)
        {
            return "Schwach (zu kurz, mindestens 8 Zeichen erforderlich)";
        }

        bool hasLower = Regex.IsMatch(password, "[a-z]");
        bool hasUpper = Regex.IsMatch(password, "[A-Z]");
        bool hasDigit = Regex.IsMatch(password, "[0-9]");
        bool hasSpecial = Regex.IsMatch(password, "[!@#$%^&*()\\-_=+\\[\\]{}|;:,.<>?/]");
        int strengthScore = (hasLower ? 1 : 0) + (hasUpper ? 1 : 0) + (hasDigit ? 1 : 0) + (hasSpecial ? 1 : 0);

        if (strengthScore == 4)
        {
            return "Stark";
        }
        else if (strengthScore == 3)
        {
            return "Mittel";
        }
        else
        {
            return "Schwach";
        }
    }
}
