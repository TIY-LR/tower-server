using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IronTower.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class IronTowerUser : IdentityUser
    {
        public Game Game { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IronTowerUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class IronTowerDBContext : IdentityDbContext<IronTowerUser>
    {
        public IronTowerDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static IronTowerDBContext Create()
        {
            return new IronTowerDBContext();
        }

        public System.Data.Entity.DbSet<Game> Games { get; set; }
        public System.Data.Entity.DbSet<Structure> Structures { get; set; }
    }
}