
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webapi.Model;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext class with the specified DbContext options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // The base constructor handles initializing the DbContext with the provided options.
        }
    public DbSet<Product> products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Change table name for IdentityRole entity
        modelBuilder.Entity<IdentityRole>()
            .ToTable("RolesTable");
        
        // Change table name for IdentityUser entity
        modelBuilder.Entity<ApplicationUser>()
            .ToTable("UsersTable");
        modelBuilder.Entity<RegistrationModel>()
          .ToTable("RegistrationTable");
        
        // Change table name for IdentityRoleClaim entity
        modelBuilder.Entity<IdentityRoleClaim<string>>()
            .ToTable("RoleClaimsTable");

        // Change table name for IdentityUserClaim entity
        modelBuilder.Entity<IdentityUserClaim<string>>()
            .ToTable("UserClaimsTable");

        // Change table name for IdentityUserLogin entity
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .ToTable("UserLoginsTable");

        // Change table name for IdentityUserRole entity
        modelBuilder.Entity<IdentityUserRole<string>>()
            .ToTable("UserRolesTable");

        // Change table name for IdentityUserToken entity
        modelBuilder.Entity<IdentityUserToken<string>>()
            .ToTable("UserTokensTable");
        SeedData(modelBuilder);
    }

    // seed data 
    private static void SeedData(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin" },
            new IdentityRole { Name = "User" }

            );
    }

}