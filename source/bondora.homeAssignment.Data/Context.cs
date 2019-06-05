using Microsoft.EntityFrameworkCore;

namespace bondora.homeAssignment.Data
{
    public partial class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> EquipmentTypes { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<BonusPoint> BonusPoints { get; set; }
        public DbSet<CategoryBonusPoint> CategoryBonusPoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("bondoraApp");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            void ExceptDeleted<T>() where T : class, IDeleteable => modelBuilder.Entity<T>(entity => entity.HasQueryFilter(a => !a.Deleted));

            ExceptDeleted<User>();
            ExceptDeleted<Product>();
            ExceptDeleted<ProductCategory>();
            ExceptDeleted<CartItem>();
            ExceptDeleted<Price>();
            ExceptDeleted<BonusPoint>();
            ExceptDeleted<CategoryBonusPoint>();
            ConfigureSeedData(modelBuilder);
        }

    }
}
