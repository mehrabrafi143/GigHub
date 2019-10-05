using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using GigHub.Core.Models;

namespace GigHub.Persistance.EntityConfigarations
{
	public class ApplicationUserConfigurations : EntityTypeConfiguration<ApplicationUser>
	{
		public ApplicationUserConfigurations()
		{
			Property(a => a.Name)
				.IsRequired()
				.HasMaxLength(50);

			HasMany(a => a.Followers)
				.WithRequired(a => a.Followee)
				.WillCascadeOnDelete(false);

			HasMany(a => a.Followees)
				.WithRequired(a => a.Follower)
				.WillCascadeOnDelete(false);

			HasMany(a => a.UserNotifications)
				.WithRequired(u => u.User)
				.WillCascadeOnDelete(false);
		}
	}
}