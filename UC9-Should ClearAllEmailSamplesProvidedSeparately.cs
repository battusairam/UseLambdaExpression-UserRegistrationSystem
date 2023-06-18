using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class EmailValidator
{
    public static void Main(string[] args)
    {
        List<string> emailSamples = new List<string>()
        {
            "abc.xyz@bl.co.in",
            "test.email@domain.com",
            "invalid.email",
            "name@.com"
        };

        Console.WriteLine("Validating Email Samples:");

        emailSamples.ForEach(email =>
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
        });

        Console.ReadLine();
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
    }
}
