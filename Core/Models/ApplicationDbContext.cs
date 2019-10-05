using System.Data.Entity;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Persistance
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		//Models
	    public DbSet<Gig> Gigs { get; set; }
	    public DbSet<Genre> Genres { get; set; }
	    public DbSet<Attendance> Attendances { get; set; }
	    public DbSet<Follow> Follows { get; set; }
	    public DbSet<Notification> Notifications { get; set; }
	    public DbSet<UserNotification> UserNotifications { get; set; }
		//End Models


		//Default Methods 
		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Attendance>()
		        .HasRequired(a => a.Gig)
		        .WithMany(g => g.Attendances)
		        .WillCascadeOnDelete(false);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany(f => f.Followees)
				.WithRequired(f => f.Follower)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany(a => a.Followers)
				.WithRequired(f => f.Followee)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<UserNotification>()
				.HasRequired(u => u.User)
				.WithMany(u => u.UserNotifications)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
        }
    }
}