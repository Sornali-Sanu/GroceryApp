using GroceryAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryAppApi.Extentions
{
    public static class ApplicationBuilder
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                var connectionString = configuration.GetConnectionString("con");
                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentException("Connection string 'con' not found in appsettings.json");

                services.AddDbContext<GroceryDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("connectionString")));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error configuring DbContext: {ex.Message}");
            }
            services.AddControllers();

            services.AddCors();
            return services;
        }
    }
}
