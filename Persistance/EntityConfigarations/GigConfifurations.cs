using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using GigHub.Core.Models;

namespace GigHub.Persistance.EntityConfigarations
{
	public class GigConfifurations : EntityTypeConfiguration<Gig>
	{
		public GigConfifurations()
		{
			Property(g => g.ArtistId)
				.IsRequired()
				.HasMaxLength(128);

			Property(g => g.Venue)
				.IsRequired()
				.HasMaxLength(255);

			Property(g => g.GenreId)
				.IsRequired();

			HasMany(a => a.Attendances)
				.WithRequired(g => g.Gig)
				.WillCascadeOnDelete(false);

		}
	}
}