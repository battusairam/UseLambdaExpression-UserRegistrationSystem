using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

[TestFixture]
public class EmailValidatorTests
{
    [TestCase("abc.xyz@bl.co.in")]
    [TestCase("test.email@domain.com")]
    [TestCase("invalid.email")]
    [TestCase("name@.com")]
    public void ValidateEmail_ParameterizedTest(string email)
    {
        Assert.DoesNotThrow(() => ValidateEmail(email));
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
