using System;
using System.Collections.Generic; // Don't forget to include this namespace

namespace JituCourses
{
    public enum LoginRegister
    {
        Login = 1,
        Register = 2,
        Exit = 3,
    }

    class Program
    {
        static void Main()
        {
            List<LoginRegister> loginRegister = new List<LoginRegister>(); // Define the list here
            
            foreach (LoginRegister option in Enum.GetValues(typeof(LoginRegister)))
            {
                loginRegister.Add(option);
            }

            ShowOptions(loginRegister);
        }

        static void ShowOptions(List<LoginRegister> options)
        {
            Console.WriteLine("Choose an option:");
            foreach (LoginRegister option in options)
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            Console.WriteLine("select way to proceed");
            string selectedOption = Console.ReadLine();

            List<UserDTO> users = new List<UserDTO>();

            Login existingUser = new Login();
            
                switch (selectedOption)
                {
                    case  "1":
                        Console.WriteLine("Selected: Login");
                        Login newLogin = new Login();
                        newLogin.LoginUser();
                        break;
                    case  "2":
                        Console.WriteLine("Selected: Register");
                        Register newUser = new Register();
                        newUser.NewUser(users);
                        break;
                    case "3":
                        Console.WriteLine("Selected: Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
           
        }
    }
}

