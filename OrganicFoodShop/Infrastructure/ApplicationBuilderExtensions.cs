using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using OrganicFoodShop.Data;

namespace OrganicFoodShop.Infrastructure
{

    // za da se migrira vseki pyt kato se vkliu4i prilojenieto, vmesto
    // da se pishe v Startup tova, pravim klas s extension method
    // app.ApplicationServices.GetService<ShopDbContext>().Database.Migrate();

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            //syzdavam scope za dbcontexta
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<ShopDbContext>();

            data.Database.Migrate();

            return app;
        }
    }
}
