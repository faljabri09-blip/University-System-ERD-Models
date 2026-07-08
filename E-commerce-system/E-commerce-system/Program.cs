using ECommerce_Solution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Linq;
namespace ECommerce_Solution
{

    public class Program
    {
        public static E_ComerceContext context = new E_ComerceContext();

        //Add operations
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


        //Update operations
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

        public static void CancleOrder(E_ComerceContext context)
        {

            Console.WriteLine("Enter order Id :");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.orderId == orderId);

            if (order == null)
            {
                Console.WriteLine("Order not found...");
                return;
            }

            //Load all ProductOrders for this order
            context.Entry(order).Collection(o => o.ProductOrders).Load();
            

            foreach (var product in order.ProductOrders)
            {
                var productfound = context.Products.FirstOrDefault(p => p.productId == product.productId);

                if (productfound != null)
                {
                    productfound.stockQuantity += product.quantity;
                }

            }

            order.status = "cancelled";
            context.SaveChanges();

            Console.WriteLine($"Order cancelled sucessfully, order Id : {orderId}");
          
        }

        //Delete operations

        public static void DeleteReview(DbSet<Review> reviews) { 
            
            Console.WriteLine("Enter Review id:"); 
            int reviewId = int.Parse(Console.ReadLine()); 
            
            var reviewfound = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId); 
            
            if (reviewfound == null) 
            
            { 
                Console.WriteLine("Review not found...");
                return ;
            } 
            
            context.Reviews.Remove(reviewfound); 
            context.SaveChanges(); 
            Console.WriteLine("Review delete sucessfully...");
        }

        //Get operations

        public static void ViewAllProducts(DbSet<product> products)
        {
            Console.WriteLine("****** View All Products *********");

            foreach (var product in context.Products) 
            {
                Console.WriteLine($"Product name: {product.productName} | Product Price: {product.ProductPrice} | " +
                    $"Product stock {product.stockQuantity} | Available status : {product.isAvailable}");
            }

        }

        public static void FilterProductByCategoryAndPriceRange(E_ComerceContext context)
        {
            Console.WriteLine("********** Filter Product By Category And Price Range **********");

            Console.WriteLine("Enter the category Id");
            int categoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Maximum price :");
            int maxPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Manimum price :");
            int minPrice = int.Parse(Console.ReadLine());

            var products = context.Products.Where(p => p.categoryId == categoryId
                                                      && p.ProductPrice >= minPrice
                                                      && p.ProductPrice <= maxPrice)
                                           .OrderBy(p => p.ProductPrice)
                                           .ToList();

            if (!products.Any())
            {
                Console.WriteLine("Product not found..");
            }

            foreach (var product in context.Products)
            {
                Console.WriteLine($"Product id : {product.productId} | CategoryId: {product.categoryId} | Product price: {product.ProductPrice} ");

            }

        }

        public static void GetCategoryWithAllItsproducts(E_ComerceContext context)
        {
            Console.WriteLine("************* Get Category With All Its products *************");

            Console.WriteLine("Enter catogry id:");
            int catogeryId = int.Parse(Console.ReadLine());


            var category = context.Categories.Include(c => c.Products)
                                             .FirstOrDefault(c => c.categoryId == catogeryId);


            if (category == null)
            {
                Console.WriteLine("Category not found....");
                return;
            }

            Console.WriteLine($"Category id: {category.categoryId}");
            Console.WriteLine($"Category name: {category.categoryName}");
            Console.WriteLine($"Category Description: {category.description}");

            if (!category.Products.Any())
            {
                Console.WriteLine("No product found in category..");
            }

            else
            {
                foreach (var product in category.Products)

                {
                    Console.WriteLine($"Category id: {category.categoryId}");
                    Console.WriteLine($"Category name: {category.categoryName}");
                    Console.WriteLine($"Category Description: {category.description}");
                    Console.WriteLine($"Category image Url: {category.imageUrl}");
                }
            }

        }

        public static void ViewOrderHistoryWithFullDetails(E_ComerceContext context)
        {

            Console.WriteLine("******** View Order History With Full Details ******");


            Console.WriteLine("Enter user Id:");
            int userId = int.Parse(Console.ReadLine());

            var user = context.Users.Include(o => o.Orders)
                                          .ThenInclude(r => r.ProductOrders)
                                          .ThenInclude(p => p.product)
                                          .FirstOrDefault(us => us.userId == userId);

            if (user == null)
            {
                Console.WriteLine("User not found...");
                return;
            }

            if (!user.Orders.Any())
            {
                Console.WriteLine("No order found...");
            }

            foreach (var order in user.Orders)
            {
                Console.WriteLine($"Order ID : {order.orderId}");
                Console.WriteLine($"Date : {order.orderDate}");
                Console.WriteLine($"Status : {order.status}");
                Console.WriteLine($"Total : {order.totalAmount}");


                foreach (var item in order.ProductOrders)
                {
                    Console.WriteLine($"productName : {item.product.productName}");
                    Console.WriteLine($"Unit Price : {item.unitPrice}");
                }
            }
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
                Console.WriteLine("5. Update Product Price And Available ");
                Console.WriteLine("6. Cancle an order ");
                Console.WriteLine("7. Delete Review");
                Console.WriteLine("8. View All Products");
                Console.WriteLine("9. Filter product by category and price range");
                Console.WriteLine("10. Get Category with All Its products");
                Console.WriteLine("11. View order history with full details");
                Console.WriteLine("12. Exit");

                Console.WriteLine("Choose the option:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1 :RegisterNewUser(context.Users); break;
                    case 2: AddNewProduct(context);break;
                    case 3: PlaceAnOrder(context); break;
                    case 4: WriteProductRwview(context); break;
                    case 5:UpdateProductPriceAndAvailable(context.Products); break;
                    case 6: CancleOrder(context); break;
                    case 7: DeleteReview(context.Reviews); break;
                    case 8: ViewAllProducts(context.Products); break;
                    case 9: FilterProductByCategoryAndPriceRange(context); break;
                    case 10: GetCategoryWithAllItsproducts(context); break;
                    case 11: ViewOrderHistoryWithFullDetails(context) ; break;
                    case 12: ViewOrderHistoryWithFullDetails (context); break;
                    case 13: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;

                }
            }
        }
    }
}
