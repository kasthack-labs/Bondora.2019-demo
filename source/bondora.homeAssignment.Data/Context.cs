using Microsoft.EntityFrameworkCore;

namespace bondora.homeAssignment.Data
{
    public partial class DemoAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<CategoryLoyaltyProgram> CategoryLoyaltyPrograms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseSqlite("Data Source=demo.db")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            void ExceptDeleted<T>() where T : class, IDeleteable => modelBuilder.Entity<T>(entity => entity.HasQueryFilter(a => !a.Deleted));

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
