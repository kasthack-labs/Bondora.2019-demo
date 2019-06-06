using Microsoft.EntityFrameworkCore;

namespace bondora.homeAssignment.Data
{
    public partial class DemoAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> ProductCategories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<LoyaltyProgram> BonusPoints { get; set; }
        public DbSet<CategoryLoyaltyProgram> CategoryBonusPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseSqlite("Data Source=demo.db")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            void ExceptDeleted<T>() where T : class, IDeleteable => modelBuilder.Entity<T>(entity => entity.HasQueryFilter(a => !a.Deleted));

            ExceptDeleted<User>();
            ExceptDeleted<Product>();
            ExceptDeleted<Category>();
            ExceptDeleted<CartItem>();
            ExceptDeleted<Price>();
            ExceptDeleted<LoyaltyProgram>();
            ExceptDeleted<CategoryLoyaltyProgram>();
            ConfigureSeedData(modelBuilder);
        }

    }
}
