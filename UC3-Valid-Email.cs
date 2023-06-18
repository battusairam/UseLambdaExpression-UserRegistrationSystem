using System;
using System.Text.RegularExpressions;

public class UserRegistration
{
    public static void Main(string[] args)
    {
     TestEmail();
        Console.ReadLine();
    }
     public static void TestEmail()
    {
        string[] emails = { "abc.xyz@bl.co.in", "test.email@domain.com", "invalid.email", "name@.com" };

        Console.WriteLine("Validating Email:");

        foreach (string email in emails)
        {
            try
            {
                ValidateEmail(email);
                Console.WriteLine("Valid email: " + email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid email: " + email + " - " + ex.Message);
            }
        }

        Console.WriteLine();
    }
  public static void ValidateEmail(string email)
    {
        Func<string, bool> isValid = (emailAddress) =>
        {
            string pattern = @"^[a-zA-Z0-9]+([.\-_][a-zA-Z0-9]+)*@[a-zA-Z0-9]+(\.[a-zA-Z]{2,}){1,2}$";
            return Regex.IsMatch(emailAddress, pattern);
        };

        if (!isValid(email))
        {
            throw new Exception("Email is invalid");
        }
    }}
