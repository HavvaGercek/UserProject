using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserProject.Core.Entities;

namespace UserProject.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            ConfigureModelBuilderForUser(modelBuilder);

        }

        void ConfigureModelBuilderForUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.Email)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
            .HasData(
              new User
              {
                  Id = 1,
                  Name = "Leanne Graham",
                  Username = "Bret",
                  Email = "Sincere@april.biz",
                  Street = "Kulas Light",
                  Suite = "Apt. 556",
                  City = "Gwenborough",
                  Zipcode = "92998-3874",
                  Latitude = "-37.3159",
                  Longitude = "81.1496",
                  Phone = "1-770-736-8031 x56442",
                  Website = "hildegard.org",
                  Companyname = "Romaguera-Crona",
                  CatchPhrase = "Multi - layered client - server neural - net",
                  BS = "harness real-time e-markets",
                  Password = "AQAAAAEAACcQAAAAEPp1r39mlMNrBouxYUXqOXLaihJ0NVJaDMiG1NrlTK4oXz6I6Ar4M6slhf8ChxCeUg=="
              });
        }
    }
}
