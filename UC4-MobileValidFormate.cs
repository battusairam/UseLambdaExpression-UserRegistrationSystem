using System;
using System.Text.RegularExpressions;

public class UserRegistration
{
    public static void Main(string[] args)
    {       
 TestMobile();
        Console.ReadLine();
    }
    
 public static void TestMobile()
    {
        string[] mobileNumbers = { "91 9919819801", "1234567890", "123 1234567890" };

        Console.WriteLine("Validating Mobile Number:");

        foreach (string mobileNumber in mobileNumbers)
        {
            try
            {
                ValidateMobile(mobileNumber);
                Console.WriteLine("Valid mobile number: " + mobileNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid mobile number: " + mobileNumber + " - " + ex.Message);
            }
        }

        Console.WriteLine();
    }
public static void ValidateMobile(string mobileNumber)
    {
        Func<string, bool> isValid = (number) =>
        {
            string pattern = @"^(\+\d{1,3}\s)?\d{10}$";
            return Regex.IsMatch(number, pattern);
        };

        if (!isValid(mobileNumber))
        {
            throw new Exception("Mobile number is invalid");
        }
    }
