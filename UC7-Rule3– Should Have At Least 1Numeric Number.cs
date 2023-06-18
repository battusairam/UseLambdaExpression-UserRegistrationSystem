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
        Func<string, bool> hasMinimumLength = pwd => pwd.Length >= 8;

        Func<string, bool> hasUppercaseLetter = pwd => Regex.IsMatch(pwd, "[A-Z]");

        Func<string, bool> hasNumericNumber = pwd => Regex.IsMatch(pwd, "[0-9]");

        Func<string, bool> isValidPassword = pwd =>
            hasMinimumLength(pwd) &&
            hasUppercaseLetter(pwd) &&
            hasNumericNumber(pwd);

        if (!isValidPassword(password))
        {
            throw new Exception("Password is invalid");
        }
    }
}
