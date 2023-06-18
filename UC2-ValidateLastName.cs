using System;
using System.Text.RegularExpressions;

public class UserRegistration
{
    public static void Main(string[] args)
    {
        TestLastName(); 
        Console.ReadLine();
    }
  public static void TestLastName()
    {
        string[] lastNames = { "Doe", "Smith", "william", "L" };

        Console.WriteLine("Validating Last Name:");

        foreach (string lastName in lastNames)
        {
            try
            {
                ValidateLastName(lastName);
                Console.WriteLine("Valid last name: " + lastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid last name: " + lastName + " - " + ex.Message);
            }
        }

        Console.WriteLine();
    }
 public static void ValidateLastName(string lastName)
    {
        Func<string, bool> isValid = (name) =>
        {
            string pattern = "^[A-Z][a-zA-Z]{2,}$";
            return Regex.IsMatch(name, pattern);
        };

        if (!isValid(lastName))
        {
            throw new Exception("Last name is invalid");
        }
    }}
