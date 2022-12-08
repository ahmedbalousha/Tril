using BookStore.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.API.Data
{
    public class BookStoreDbContext:IdentityDbContext<AppUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserFav>().HasKey(x => new { x.AppUserId, x.BookId });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var property = entityType.FindProperty("DeletedAt") ?? entityType.AddProperty("DeletedAt", typeof(DateTime?));

                var parameter = Expression.Parameter(entityType.ClrType);

                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(DateTime?));
                var DeletedAtProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("DeletedAt"));

                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, DeletedAtProperty, Expression.Constant(null));

                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["DeletedAt"] = null;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["DeletedAt"] = DateTime.Now;
                        break;
                }
            }
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookSuggestion> BookSuggestions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContantUs> ContantUss { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<StaticPage> StaticPages { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<UserFav> UserFavs { get; set; }
        public DbSet<Zone> Zones { get; set; }



    }
}

