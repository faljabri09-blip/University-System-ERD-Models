using Microsoft.EntityFrameworkCore;
using ECommerce_Solution.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace ECommerce_Solution
{

    public class Program
    {
        public static E_ComerceContext context = new E_ComerceContext();
        
        //Add functions
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

        public static void PlaceAnOrder(E_ComerceContext context)
        {
            Console.WriteLine("Enter User Id:");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Id:");
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Quantity:");
            int quantity = int.Parse(Console.ReadLine());

            var product = context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.WriteLine("Product not found...");
                return;
            }

            if (quantity > product.stockQuantity)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            Console.WriteLine("Enter Shipping Address:");
            string shippingAddress = Console.ReadLine();

            Console.WriteLine("Enter Payment Method:");
            string paymentMethod = Console.ReadLine();

            Order newOrder = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
                totalAmount = product.ProductPrice * quantity,
                shippingAddress = shippingAddress,
                paymentMethod = paymentMethod,
                status = "Pending"
            };

            context.Orders.Add(newOrder);
            context.SaveChanges(); 

            ProductOrder productOrder = new ProductOrder
            {
                orderId = newOrder.orderId,
                productId = productId,
                quantity = quantity,
                unitPrice = product.ProductPrice
            };

            context.ProductOrders.Add(productOrder);

            product.stockQuantity -= quantity;

            context.SaveChanges();

            Console.WriteLine($"Order placed successfully. Order Id: {newOrder.orderId}");
        }

        public static void WriteProductRwview(E_ComerceContext context)
        {

            Console.WriteLine("Enter user Id");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product Id:");
            int productId = int.Parse(Console.ReadLine());

            var userfound = context.Users.FirstOrDefault(u => u.userId == userId && u.isActive == true);

            var productfound = context.Products.FirstOrDefault(p => p.productId == productId
                                                               && p.isAvailable == true);

            if (userfound == null)
            {
                Console.WriteLine("user not found..");
                return;
            }

            if (productfound == null)
            {
                Console.WriteLine("product not found");
                return;
            }


            Console.WriteLine("Enter Rating review: (rating 1-5)");
            int rating = int.Parse(Console.ReadLine());

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1-5");
            }

            Console.WriteLine("Enter comment: (optional)");
            string comment = Console.ReadLine();

            Console.WriteLine("Enter review date:");
            string reviewDate = Console.ReadLine();

            var NewReview = new Review
            {
                userId = userId,
                productId = productId,
                rating = rating,
                comment = string.IsNullOrWhiteSpace(comment) ? null : comment,
                reviewDate = DateTime.Now
            };

            context.Reviews.Add(NewReview);
            context.SaveChanges();
            Console.WriteLine($"Adding Review successfully , review id: {NewReview.reviewId}");
        }


        //update functions
        public static void UpdateProductPriceAndAvailable(DbSet<product> products)
        {

            Console.WriteLine("Enter product Id:");
            int productId = int.Parse(Console.ReadLine());

            product product = context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.WriteLine("product not found...");
                return;
            }


            Console.WriteLine("Enter product price");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enetr available product");
            bool available = bool.Parse(Console.ReadLine());
            
                product.ProductPrice  = price;
                product.isAvailable = available;
                

            context.SaveChanges();
            Console.WriteLine($"Update sucessfully, product id : {productId}");


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
                Console.WriteLine("3. Place an order");
                Console.WriteLine("4. Write a Product Review");
                Console.WriteLine("4. Update Product Price And Available ");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":RegisterNewUser(context.Users); break;
                    case "2": AddNewProduct(context);break;
                    case "3": PlaceAnOrder(context); break;
                    case "4": WriteProductRwview(context); break;
                    case "5":UpdateProductPriceAndAvailable(context.Products); break;
                    case "6": exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;

                }
            }
        }
    }
}
