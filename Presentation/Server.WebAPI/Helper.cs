using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Persistence.Context;

namespace Server.WebAPI;

public static class Helper
{
    public static void MigrateMigrations(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.Migrate();
        }
    }

    public static async Task CreateData(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Set<Product>().Any())
            {
                IList<Product> products = new List<Product>();

                for (int i = 0; i < 5000; i++)
                {
                    Random random = new();

                    Product product = new Product()
                    {
                        Name = "Product " + i,
                        Price = i + 5,
                        Stock = random.Next(1, 101)
                    };

                    products.Add(product);
                }

                context.Set<Product>().AddRange(products);

                await context.SaveChangesAsync();
            }
        }
    }
}
