using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Construcotrs
        /// <summary>
        /// 
        /// </summary>
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<MembershipType> MembershipTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Rental> Rentals { get; set; }

        /// <summary>
        /// DbTable name must be same name as the property
        /// </summary>
        public DbSet<ImdbMovie> AspNetIMDBTable { get; set; }
        #endregion
    }
}