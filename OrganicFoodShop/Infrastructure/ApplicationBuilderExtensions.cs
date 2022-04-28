using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using OrganicFoodShop.Data;
using OrganicFoodShop.Data.Models;

namespace OrganicFoodShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetRequiredService<ShopDbContext>();

            db.Database.Migrate();

            SeedCategories(db);

            SeedProducts(db);

            return app;
        }

        private static void SeedCategories(ShopDbContext db)
        {
            if (db.Categories.Any())
            {
                return;
            }

            db.Categories.AddRange(new[]
            {
                new Category {Name = "Grains, SeedsNuts, Fruits"},
                new Category {Name = "Oils, Spreads, Jams"},
                new Category {Name = "Superfoods"},
                new Category {Name = "Flours, Sweeteners"},
                new Category {Name = "Coffee, Tea"},
                new Category {Name = "Chocolates, Desserts"},
                new Category {Name = "Nutritional Supplements"},
                new Category {Name = "Drinks"},
                new Category {Name = "Cosmetics"},
                new Category {Name = "Other"}
            });

            db.SaveChanges();
        }

        private static void SeedProducts(ShopDbContext db)
        {
            if (db.Products.Any())
            {
                return;
            }

            db.Products.AddRange(new[]
            {
                new Product
                {
                    Name = "Bio Quinoa Three-coloured",
                    PriceBuy = (decimal)5.5,
                    PriceSell = (decimal)7.7,
                    Quantity = 3,
                    Barcode = "64646464",
                    CategoryId = 1,
                    Description = "Quinoa in three colours",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/7687/bio-kinoa-tricvetna-500g-zelen-image_60f67e5617c2b_600x600.jpeg?1626766957"
                },

                   new Product
                {
                    Name = "Benjamissimo Chocolate Hot Nibs",
                    PriceBuy = (decimal)4.6,
                    PriceSell = (decimal)5.9,
                    Quantity = 10,
                    Barcode = "1234567890",
                    CategoryId = 6,
                    Description = "Bio vegan chocolate with chilli",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/8063/bio-vegan-kakaov-desert-hot-nibs-benjamissimo-happy-edition-60g-image_60f683d72e77d_600x600.jpeg?1626768365"
                   },


                            new Product
            {
                Name = "Lip Balm Sun Kiss",
                PriceBuy = (decimal)2.6,
                PriceSell = (decimal)3.5,
                Quantity = 5,
                Barcode = "34353536",
                CategoryId = 9,
                Description = "Lip balm with bee wax and UV protection",
                Manufacturer = "Wooden Spoon",
                ImageURL ="https://cdncloudcart.com/25215/products/images/7597/bio-balsam-za-ustni-sun-kiss-uv-zasita-43ml-wooden-spoon-image_60f67d0c870a4_600x600.jpeg?1626766683"
            },

                 new Product
            {
                Name = "Demerara Sugar",
                PriceBuy = (decimal)5,
                PriceSell = (decimal)6,
                Quantity = 12,
                Barcode = "784389330",
                CategoryId = 4,
                Description = "Pure brown Demerara sugar",
                Manufacturer = "Bio Class",
                ImageURL ="https://cdncloudcart.com/25215/products/images/8657/bio-zahar-demerara-bio-klasa-300-g-image_60f68d33d0fa4_600x600.jpeg?1626770761"
            },

            new Product
            {
                Name = "Muscovado Sugar",
                PriceBuy = (decimal)5.4,
                PriceSell = (decimal)6.7,
                Quantity = 6,
                Barcode = "5765757",
                CategoryId = 4,
                Description = "Natiral Muscovado sugar",
                Manufacturer = "Bio Class",
                ImageURL ="https://cdncloudcart.com/25215/products/images/8714/bio-zahar-muskovado-bio-klasa-300-g-image_6163ea0f9e20d_600x600.png?1633937957"
            },

            new Product
            {
                Name = "Coconut Sugar",
                PriceBuy = (decimal)7.4,
                PriceSell = (decimal)8.7,
                Quantity = 4,
                Barcode = "75758585",
                CategoryId = 4,
                Description = "Tasty natural coconut sugar",
                Manufacturer = "Dragon Superfoods",
                ImageURL ="https://cdncloudcart.com/25215/products/images/9700/bio-kokosova-zahar-250g-dragon-superfoods-image_61fa4e3b67fb0_600x600.png?1643794003"
            },

            new Product
            {
                Name = "Bio Basmati Rice",
                PriceBuy = (decimal)4.5,
                PriceSell = (decimal)5.7,
                Quantity = 14,
                Barcode = "6464778",
                CategoryId = 1,
                Description = "Bio rice",
                Manufacturer = "Smart Organic",
                ImageURL ="https://cdncloudcart.com/25215/products/images/7696/bio-oriz-basmati-kafav-2kg-smart-organic-image_60f67e5d3b8df_600x600.jpeg?1626766963"
            },

            new Product
                {
                    Name = "Bio Flax Seed Crushed",
                    PriceBuy = (decimal)2.5,
                    PriceSell = (decimal)3.9,
                    Quantity = 9,
                    Barcode = "35346778",
                    CategoryId = 1,
                    Description = "",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/7679/bio-seme-leneno-scukano-1kg-smart-organic-image_60f67e304a841_600x600.jpeg?1626766920"
                },

                    new Product
                {
                    Name = "Bio Black Lentils Beluga",
                    PriceBuy = (decimal)4.5,
                    PriceSell = (decimal)5.85,
                    Quantity = 12,
                    Barcode = "879073633",
                    CategoryId = 1,
                    Description = "Certified bio product",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/8669/bio-lesa-beluga-bio-klasa-500-g-image_60f68d5c95eea_600x600.jpeg?1626770802"
                },

                     new Product
                {
                    Name = "Bio Mung Beans",
                    PriceBuy = (decimal)5,
                    PriceSell = (decimal)6,
                    Quantity = 9,
                    Barcode = "78394348",
                    CategoryId = 1,
                    Description = "Certified bio product",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/9843/bio-belen-bob-mung-500g-bio-klasa-image_618e86b4f1f98_600x600.png?1636730571"
                },

                      new Product
                {
                    Name = "Casa Kakau Chocolate Rose Water",
                    PriceBuy = (decimal)4.2,
                    PriceSell = (decimal)5,
                    Quantity = 3,
                    Barcode = "2535646",
                    CategoryId = 6,
                    Description = "Bio craft chocolate with rose water",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/7629/zanaatcijski-sokolad-s-balgarska-rozova-voda-i-kardamon-70g-casa-kakau-image_60f67d8ba5b6f_600x600.jpeg?1626766752"
                   },

                                  new Product
                {
                    Name = "Benjamissimo Dark Chocolate",
                    PriceBuy = (decimal)5.2,
                    PriceSell = (decimal)7,
                    Quantity = 5,
                    Barcode = "353464758",
                    CategoryId = 6,
                    Description = "",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/7951/bio-tamen-sokolad-90--benjamissimo-70g-image_60f682204026d_600x600.jpeg?1626767924"
                   },

                                                               new Product
                {
                    Name = "Benjamissimo Chocolate Curcuma Ginger",
                    PriceBuy = (decimal)6.2,
                    PriceSell = (decimal)7.9,
                    Quantity = 6,
                    Barcode = "36475858",
                    CategoryId = 6,
                    Description = "",
                    Manufacturer = "Smart Organic",
                    ImageURL ="https://cdncloudcart.com/25215/products/images/8064/bio-vegan-kakaov-desert-curcuma-ginger-lemon-benjamissimo-happy-edition-60g-image_60f683d87fd7a_600x600.jpeg?1626768365"
                   },
            });

            db.SaveChanges();
        }
    }
}
