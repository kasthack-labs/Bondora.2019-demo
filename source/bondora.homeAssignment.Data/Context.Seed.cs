using Microsoft.EntityFrameworkCore;

namespace bondora.homeAssignment.Data
{
    public partial class DemoAppContext
    {
        private static void ConfigureSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>().HasData(
                new Price
                {
                    Id = 1,
                    Deleted = false,
                    Name = "OneTime",
                    Value = 100,
                },
                new Price
                {
                    Id = 2,
                    Deleted = false,
                    Name = "Regular",
                    Value = 40,
                },
                new Price
                {
                    Id = 3,
                    Deleted = false,
                    Name = "Premium",
                    Value = 100,
                }
            );

            modelBuilder.Entity<LoyaltyProgram>().HasData(
                new LoyaltyProgram
                {
                    Id = 1,
                    Deleted = false,
                    Name = "Regular bonus program",
                    Formula = "1",
                },
                new LoyaltyProgram
                {
                    Id = 2,
                    Deleted = false,
                    Name = "Heavy equipment bonus program",
                    Formula = "2",
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Deleted = false,
                    Name = "Heavy equipment",
                    PricingFormula = "OneTime + Premium * duration",
                },
                new Category
                {
                    Id = 2,
                    Deleted = false,
                    Name = "Regular equipment",
                    PricingFormula = "OneTime + min(duration, 2) * Premium + max(0, duration - 2) * Regular"
                },
                new Category
                {
                    Id = 3,
                    Deleted = false,
                    Name = "Specialized equipment",
                    PricingFormula = "min(duration, 3) * Premium + max(0, duration - 3) * Regular"
                }
            );

            modelBuilder.Entity<CategoryLoyaltyProgram>().HasData(
                new CategoryLoyaltyProgram
                {
                    Id = 1,
                    Deleted = false,
                    BonusPointsId = 2,
                    ProductCategoryId = 1,
                },
                new CategoryLoyaltyProgram
                {
                    Id = 2,
                    Deleted = false,
                    BonusPointsId = 1,
                    ProductCategoryId = 2,
                },
                new CategoryLoyaltyProgram
                {
                    Id = 3,
                    Deleted = false,
                    BonusPointsId = 1,
                    ProductCategoryId = 3,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Deleted = false,
                    CategoryId = 1,
                    Name = "Caterpillar bulldozer",
                    Image = "https://i.imgur.com/XmUfJ41.png",
                },
                new Product
                {
                    Id = 2,
                    Deleted = false,
                    CategoryId = 2,
                    Name = "KamAZ truck",
                    Image = "https://i.imgur.com/8bP88dn.png"
                },
                new Product
                {
                    Id = 3,
                    Deleted = false,
                    CategoryId = 1,
                    Name = "Komatsu crane",
                    Image = "https://i.imgur.com/JUH91Xj.png",
                },
                new Product
                {
                    Id = 4,
                    Deleted = false,
                    CategoryId = 2,
                    Name = "Volvo steamroller",
                    Image = "https://i.imgur.com/um0dalY.png",
                },
                new Product
                {
                    Id = 5,
                    Deleted = false,
                    CategoryId = 3,
                    Name = "Bosch jackhammer",
                    Image = "https://i.imgur.com/AilecFp.png",
                }
            );
        }
    }
}
