using Microsoft.EntityFrameworkCore;
using ECommerce_Solution.Models;

namespace ECommerce_Solution
{

    public class Program
    {
        public static E_ComerceContext context = new E_ComerceContext();

        public static void RegisterNewUser(DbSet<User> users)
        {
            Console.WriteLine("Registering a new user...");

            Console.Write("Enter username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter phone number (optional): ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter address (optional): ");
            string address = Console.ReadLine();

            int userId = context.Users.Count() + 1; // Generate a new userId 

            context.Users.Add(new User

            {
                userName = userName,
                email = email,
                passwordHash = password, // In a real application, you should hash the password
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber,
                address = string.IsNullOrWhiteSpace(address) ? null : address,
                registrationDate = DateTime.Now,
                isActive = true
            });

            context.SaveChanges();

            Console.WriteLine($"User registered successfully. UserId : {userId}");
        }

        
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the E-commerce system!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Register a new user");
                Console.WriteLine("2. ");
                Console.WriteLine("3. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterNewUser(context.Users);
                        break;
                    case "2":

                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
