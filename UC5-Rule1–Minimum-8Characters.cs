using System;
using System.Text.RegularExpressions;

public class PasswordValidator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a password:");
        string password = Console.ReadLine();

        try
        {
            ValidatePassword(password);
            Console.WriteLine("Valid password");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid password: " + ex.Message);
        }

        Console.ReadLine();
    }

    public static void ValidatePassword(string password)
    {
        Func<string, bool> isValid = (pwd) =>
        {
            string pattern = @"^.{8,}$";
            return Regex.IsMatch(pwd, pattern);
        };

        if (!isValid(password))
        {
            throw new Exception("Password must have a minimum of 8 characters");
        }
    }
}
