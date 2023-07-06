using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateAuditingFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditingFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }

        private void UpdateAuditingFields()
        {
            foreach (var entity in ChangeTracker.Entries<AuditBase>())
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.UtcNow;

                        break;
                }
            }
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleDetail> SaleDetails { get; set; }

        public DbSet<TemporalSale> TemporalSales { get; set; }


        //public DbSet<State> States { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Country> Countries { get; set; }
    }
}