
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return; 
            }

            var restaurants = new[]
            {
                new Models.Restaurant { Name = "Pizza Hut", Description = "Italian Restaurant", Address = "123 Main St", Phone = "123-456-7890" },
                new Models.Restaurant { Name = "Burger King", Description = "Fast Food", Address = "456 Oak St", Phone = "987-654-3210" }
            };

            context.Restaurants.AddRange(restaurants);
            context.SaveChanges();

            var products = new[]
            {
                new Models.Product { Name = "Margherita Pizza", Description = "Classic cheese pizza", Price = 12.99m, RestaurantId = 1 },
                new Models.Product { Name = "Pepperoni Pizza", Description = "Pizza with pepperoni", Price = 14.99m, RestaurantId = 1 },
                new Models.Product { Name = "Whopper", Description = "Beef burger", Price = 8.99m, RestaurantId = 2 },
                new Models.Product { Name = "Cheeseburger", Description = "Burger with cheese", Price = 7.99m, RestaurantId = 2 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var users = new[]
            {
                new Models.User { Name = "John Doe", Email = "john@example.com", Address = "789 Pine St", Phone = "555-1234" },
                new Models.User { Name = "Jane Smith", Email = "jane@example.com", Address = "321 Maple St", Phone = "555-5678" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}