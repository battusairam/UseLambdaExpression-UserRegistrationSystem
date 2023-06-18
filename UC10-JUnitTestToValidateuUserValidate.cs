using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class UserRegistrationTests
{
    [Test]
    public void ValidateFirstName_HappyTestCase()
    {
        // Arrange
        string firstName = "John";

        // Act and Assert
        Assert.That(() => ValidateFirstName(firstName), Throws.Nothing);
    }

    [Test]
    public void ValidateFirstName_SadTestCase()
    {
        // Arrange
        string firstName = "j";

        // Act and Assert
        Assert.That(() => ValidateFirstName(firstName), Throws.Exception.With.Message.EqualTo("First name is invalid"));
    }

    [Test]
    public void ValidateLastName_HappyTestCase()
    {
        // Arrange
        string lastName = "Doe";

        // Act and Assert
        Assert.That(() => ValidateLastName(lastName), Throws.Nothing);
    }

    [Test]
    public void ValidateLastName_SadTestCase()
    {
        // Arrange
        string lastName = "w";

        // Act and Assert
        Assert.That(() => ValidateLastName(lastName), Throws.Exception.With.Message.EqualTo("Last name is invalid"));
    }

    [Test]
    public void ValidateEmail_HappyTestCase()
    {
        // Arrange
        string email = "test.email@example.com";

        // Act and Assert
        Assert.That(() => ValidateEmail(email), Throws.Nothing);
    }

    [Test]
    public void ValidateEmail_SadTestCase()
    {
        // Arrange
        string email = "invalid.email";

        // Act and Assert
        Assert.That(() => ValidateEmail(email), Throws.Exception.With.Message.EqualTo("Email is invalid"));
    }

    [Test]
    public void ValidateMobile_HappyTestCase()
    {
        // Arrange
        string mobileNumber = "1234567890";

        // Act and Assert
        Assert.That(() => ValidateMobile(mobileNumber), Throws.Nothing);
    }

    [Test]
    public void ValidateMobile_SadTestCase()
    {
        // Arrange
        string mobileNumber = "123 1234567890";

        // Act and Assert
        Assert.That(() => ValidateMobile(mobileNumber), Throws.Exception.With.Message.EqualTo("Mobile number is invalid"));
    }

    [Test]
    public void ValidatePassword_HappyTestCase()
    {
        // Arrange
        string password = "P@ssw0rd";

        // Act and Assert
        Assert.That(() => ValidatePassword(password), Throws.Nothing);
    }

    [Test]
    public void ValidatePassword_SadTestCase()
    {
        // Arrange
        string password = "12345678";

        // Act and Assert
        Assert.That(() => ValidatePassword(password), Throws.Exception.With.Message.EqualTo("Password is invalid"));
    }

    // Validate the first name using a lambda expression
    public static void ValidateFirstName(string firstName)
    {
        Func<string, bool> isValid = name => Regex.IsMatch(name, "^[A-Z][a-zA-Z]{2,}$");

        if (!isValid(firstName))
        {
            throw new Exception("First name is invalid");
        }
    }
    public static void ValidateLastName(string lastName)
    {
        Func<string, bool> isValid = name => Regex.IsMatch(name, "^[A-Z][a-zA-Z]{2,}$");

        if (!isValid(lastName))
        {
            throw new Exception("Last name is invalid");
        }
    }
    public static void ValidateEmail(string email)
    {
        Func<string, bool> isValid = emailAddress => Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9]+([.\-_][a-zA-Z0-9]+)*@[a-zA-Z0-9]+(\.[a-zA-Z]{2,}){1,2}$");

        if (!isValid(email))
        {
            throw new Exception("Email is invalid");
        }
    }

    public static void ValidateMobile(string mobileNumber)
    {
        Func<string, bool> isValid = number => Regex.IsMatch(number, @"^(\+\d{1,3}\s)?\d{10}$");

        if (!isValid(mobileNumber))
        {
            throw new Exception("Mobile number is invalid");
        }
    }

    public static void ValidatePassword(string password)
    {
        Func<string, bool> isValid = pwd => Regex.IsMatch(pwd, @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$");

        if (!isValid(password))
        {
            throw new Exception("Password is invalid");
        }
    }
}
