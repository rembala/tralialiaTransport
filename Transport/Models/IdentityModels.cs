using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Transport.Core.Configurations;

namespace Transport.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TransportContext", throwIfV1Schema: false)
        {
        }
        public DbSet<TransportEnginePowers> TransportEnginePower { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("MyUsers", "transport").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("MyUserRoles", "transport");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("MyUserLogins", "notUsed");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("MyUserClaims", "notUsed");
            modelBuilder.Entity<IdentityRole>().ToTable("MyRoles", "transport");
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}