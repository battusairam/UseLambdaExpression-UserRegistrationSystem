using System.Text.RegularExpressions;

namespace UseLambdaExpression_UserRegistrationSystem
{

public class UserRegistration
        {
            public static void Main(string[] args)
            {
                TestFirstName();

                Console.ReadLine();
            }
            public static void TestFirstName()
            {
                string[] firstNames = { "battu", "Sairam", "jane", "A" };

                Console.WriteLine("Validating First Name:");

                foreach (string firstName in firstNames)
                {
                    try
                    {
                        ValidateFirstName(firstName);
                        Console.WriteLine("Valid first name: " + firstName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid first name: " + firstName + " - " + ex.Message);
                    }
                }

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
                    throw new Exception("First name is invalid");
                }
            }
        }
    }
    
