using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using OrganicFoodShop.Data;

namespace OrganicFoodShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {

        ///май не ми трябва този клас,не става миграция с това
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            //syzdavam scope za dbcontexta
            using var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetRequiredService<ShopDbContext>();

            db.Database.Migrate();

            return app;
        }
    }
}
