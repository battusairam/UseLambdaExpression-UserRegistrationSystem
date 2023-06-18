using System;
using System.Text.RegularExpressions;

public class InvalidUserDetailsException : Exception
{
    public InvalidUserDetailsException(string message) : base(message)
    {
    }
}

public class UserRegistration
{
    public static void Main(string[] args)
    {
        // Test the user registration validation
        TestFirstName();
        TestLastName();
        TestEmail();
        TestMobile();
        TestPassword();

        // Test the email validation using parameterized test
        TestEmailParameterized();

        Console.ReadLine();
    }

    public static void TestFirstName()
    {
        string[] firstNames = { "John", "Adam", "jane", "A" };

        Console.WriteLine("Validating First Name:");

        foreach (string firstName in firstNames)
        {
            try
            {
                ValidateFirstName(firstName);
                Console.WriteLine("Valid first name: " + firstName);
            }
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid first name: " + firstName + " - " + ex.Message);
            }
        }

        Console.WriteLine();
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
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid last name: " + lastName + " - " + ex.Message);
            }
        }

        Console.WriteLine();
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
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid email: " + email + " - " + ex.Message);
            }
        }

        Console.WriteLine();
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
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid mobile number: " + mobileNumber + " - " + ex.Message);
            }
        }

        Console.WriteLine();
    }

    public static void TestPassword()
    {
        string[] passwords = { "password123", "Abcdefg1", "12345678", "P@ssw0rd" };

        Console.WriteLine("Validating Password:");

        foreach (string password in passwords)
        {
            try
            {
                ValidatePassword(password);
                Console.WriteLine("Valid password: " + password);
            }
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid password: " + password + " - " + ex.Message);
            }
        }

        Console.WriteLine();
    }

    public static void TestEmailParameterized()
    {
        string[] emails = { "abc.xyz@bl.co.in", "test.email@domain.com", "invalid.email", "name@.com" };

        Console.WriteLine("Validating Email using Parameterized Test:");

        Array.ForEach(emails, email =>
        {
            try
            {
                ValidateEmail(email);
                Console.WriteLine("Valid email: " + email);
            }
            catch (InvalidUserDetailsException ex)
            {
                Console.WriteLine("Invalid email: " + email + " - " + ex.Message);
            }
        });

        Console.WriteLine();
    }

    public static void ValidateFirstName(string firstName)
    {
        Func<string, bool> isValid = (name) =>
        {
            string pattern = "^[A-Z][a-zA-Z]{2,}$";
            return Regex.IsMatch(name, pattern);
        };

        if (!isValid(firstName))
        {
            throw new InvalidUserDetailsException("First name is invalid");
        }
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
            throw new InvalidUserDetailsException("Last name is invalid");
        }
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
            throw new InvalidUserDetailsException("Email is invalid");
        }
    }

    // Validate the mobile number using a lambda expression
    public static void ValidateMobile(string mobileNumber)
    {
        Func<string, bool> isValid = (number) =>
        {
            string pattern = @"^(\+\d{1,3}\s)?\d{10}$";
            return Regex.IsMatch(number, pattern);
        };

        if (!isValid(mobileNumber))
        {
            throw new InvalidUserDetailsException("Mobile number is invalid");
        }
    }

    public static void ValidatePassword(string password)
    {
        Func<string, bool> isValid = (pwd) =>
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$";
            return Regex.IsMatch(pwd, pattern);
        };

        if (!isValid(password))
        {
            throw new InvalidUserDetailsException("Password is invalid");
        }
    }
}
