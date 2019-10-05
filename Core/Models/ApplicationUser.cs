using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Core.Models
{
	public class ApplicationUser : IdentityUser
	{

		public string Name { get; set; }

		public ICollection<Follow> Followees { get; set; }
		public ICollection<Follow> Followers { get; set; }
		public ICollection<UserNotification> UserNotifications { get; set; }


		public ApplicationUser()
		{
			Followees = new List<Follow>();
			Followers = new List<Follow>();
			UserNotifications = new List<UserNotification>();
		}


		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			userIdentity.AddClaim(new Claim("Name",Name));
			return userIdentity;
		}

		public void Notify(Notification notification)
		{
			var userNotification = new UserNotification(this,notification);
			UserNotifications.Add(userNotification);
		}

		public bool HasFollower()
		{
			return Followers.Count != 0;
		}

		public bool IsFollowing(string userId)
		{
			return Followers.Any(f => f.FolloweeId == Id && f.FollowerId == userId);
		}
	}
}