using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Core.Models
{
	public class Gig
	{
		public int Id { get; set; }

		public ApplicationUser Artist { get; set; }
	    public string ArtistId { get; set; }
		public string Venue { get; set; }
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateTime { get; set; }
		public bool IsCancel { get; private set; }
		public ICollection<Attendance> Attendances { get; private set; }
		public Gig()
		{
			Attendances = new List<Attendance>();
		}

		public void Cancel()
		{
			IsCancel = true;
			var notification = Notification.GigCancel(this);

			foreach (var attendee in Attendances.Select(a => a.Attendee))
			{
				attendee.Notify(notification);
			}
		}
		

		public void Modify(DateTime modelDateTime, string modelVenue, byte modelGenreId)
		{
			var notification = Notification.GigUpdated(this,DateTime,Venue);
			DateTime = modelDateTime;
			Venue = modelVenue;
			GenreId = modelGenreId;

			foreach (var attendance in Attendances.Select(a => a.Attendee))
			{
				attendance.Notify(notification);
			}
		}

		public void Created()
		{
			var notification = Notification.GigCreated(this);

			foreach (var follower in Artist.Followers.Select(f => f.Follower))
			{
				follower.Notify(notification);
			}

		}

		public bool IsGoing(string userId)
		{
			return Attendances.Any(a => a.AttendeeId == userId && a.GigId == Id);
		}
	}
}