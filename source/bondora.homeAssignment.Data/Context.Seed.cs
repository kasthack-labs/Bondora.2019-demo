using Microsoft.EntityFrameworkCore;

namespace bondora.homeAssignment.Data
{
    public partial class Context
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

            modelBuilder.Entity<BonusPoint>().HasData(
                new BonusPoint
                {
                    Id = 1,
                    Deleted = false,
                    Name = "Regular bonus program",
                    Value = 1,
                },
                new BonusPoint
                {
                    Id = 1,
                    Deleted = false,
                    Name = "Heavy equipment bonus program",
                    Value = 2,
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    Deleted = false,
                    Name = "Heavy",
                    PricingFormula = "OneTime + Premium * duration",
                },
                new ProductCategory
                {
                    Id = 2,
                    Deleted = false,
                    Name = "Regular",
                    PricingFormula = "OneTime + min(duration, 2) * Premium + max(0, duration - 2) * Regular"
                },
                new ProductCategory
                {
                    Id = 3,
                    Deleted = false,
                    Name = "Specialized",
                    PricingFormula = "min(duration, 3) * Premium + max(0, duration - 3) * Regular"
                }
            );

            modelBuilder.Entity<CategoryBonusPoint>().HasData(
                new CategoryBonusPoint
                {
                    Id = 1,
                    Deleted = false,
                    BonusPointsId = 2,
                    ProductCategoryId = 1,
                },
                new CategoryBonusPoint
                {
                    Id = 2,
                    Deleted = false,
                    BonusPointsId = 1,
                    ProductCategoryId = 2,
                },
                new CategoryBonusPoint
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
                    EquipmentTypeId = 1,
                    Name = "Caterpillar bulldozer",
                },
                new Product
                {
                    Id = 2,
                    Deleted = false,
                    EquipmentTypeId = 2,
                    Name = "KamAZ truck",
                },
                new Product
                {
                    Id = 3,
                    Deleted = false,
                    EquipmentTypeId = 1,
                    Name = "Komatsu crane",
                },
                new Product
                {
                    Id = 4,
                    Deleted = false,
                    EquipmentTypeId = 2,
                    Name = "Volvo steamroller",
                },
                new Product
                {
                    Id = 2,
                    Deleted = false,
                    EquipmentTypeId = 3,
                    Name = "Bosch jackhammer",
                }
            );
        }
    }
}
