using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Practica.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public virtual Usuario usuario { get; set; }
    }

    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        //public System.Data.Entity.DbSet<usuario> User { get; set; }
        //public virtual DbSet<Usuario> Usuario { get; set; }
    }
}