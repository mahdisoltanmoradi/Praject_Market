using Common.Utilities;
using Data.Contracts;
using Entities.Baskets;
using Entities.Catalogs;
using Entities.Chat;
using Entities.Common;
using Entities.Discount;
using Entities.Notification;
using Entities.Order;
using Entities.Payments;
using Entities.Product;
using Entities.Role;
using Entities.User;
using Entities.Wallet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<ClientChatMessage> ClientChatMessages { get; set; }
        public DbSet<ClientChatRoom> ClientChatRooms { get; set; }
        public DbSet<FavoriteUser> FavoriteUsers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public DbSet<CatalogItemImage> CatalogItemImages { get; set; }
        public DbSet<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<ProductCategory>()
                .HasQueryFilter(g => !g.IsDelete);

            modelBuilder.Entity<BasketItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<Basket>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            modelBuilder.Entity<Order>().OwnsOne(p=>p.Address);

            base.OnModelCreating(modelBuilder);

            var entitiesAssembly = typeof(IEntity).Assembly;

            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }

        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
    }
}
