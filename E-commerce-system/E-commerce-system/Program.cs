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



            User newUser = new User

            {

                // id will be generated automatically by the database

                userName = userName,
                email = email,
                passwordHash = password, // In a real application, you should hash the password
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber,
                address = string.IsNullOrWhiteSpace(address) ? null : address,
                registrationDate = DateTime.Now,
                isActive = true
            };


            ////insert a new user with hardcoded values for testing purposes

            //User newUser = new User
            //{
            //    userName = "Fatma_Aljabri",
            //    email = "fatma@example.com",
            //    passwordHash = "hashed_password_here",
            //    fullName = "Fatma ALjabri",
            //    registrationDate = DateTime.Now,
            //    isActive = true
            //};

            context.Users.Add(newUser);

            context.SaveChanges(); // insert into user

            Console.WriteLine($"User registered successfully. UserId : {newUser.userId}");

            //User saved = context.Users.OrderBy(u => u.userId).Last(); // generated id from database
            //Console.WriteLine($"User registered successfully. UserId : {saved.userId}");
        }

        public static void AddNewProduct(E_ComerceContext context)
        {

            //foreach (var category in context.Categories)
            //{
            //    Console.WriteLine($"{category.categoryId}  ---  {category.categoryName}");
            //    return;
            //}

            Console.WriteLine("Choose Category Id :");
            int categoryId = int.Parse(Console.ReadLine());

            var categoryfound = context.Categories.FirstOrDefault(c => c.categoryId == categoryId);

            if (categoryfound == null)
            {
                Console.WriteLine("Category not found...");
                return;
            }


            Console.WriteLine("Enter Product Name :");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter Description (optional):");
            string description = Console.ReadLine();


            Console.WriteLine("Enter Product Price");
            decimal ProductPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter stock Quantity");
            int stockQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter image Url (optional)");
            string imageUrl = Console.ReadLine();

            var NewProduct = new product
            {
                productName = productName,
                description = string.IsNullOrWhiteSpace(description) ? null : description,
                ProductPrice = ProductPrice,
                stockQuantity = stockQuantity,
                imageUrl = string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl,
                categoryId = categoryId,
                createAt = DateTime.Now,
                isAvailable = true
            };

            context.Products.Add(NewProduct);
            context.SaveChanges();
            Console.WriteLine($"Product add sucessfully , Product Id : {NewProduct.productId}");

        }

        
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the E-commerce system!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Register a new user");
                Console.WriteLine("2. Add new product to a category");
                Console.WriteLine("3. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterNewUser(context.Users);
                        break;
                    case "2":
                        AddNewProduct(context);
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
