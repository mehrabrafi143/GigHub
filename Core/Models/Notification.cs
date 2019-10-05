using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.Models
{
	public class Notification
	{
		public int Id { get; private set; }

		public DateTime DateTime { get; private set; }

		public NotificationType NotificationType { get; private set; }

		public DateTime? OriginalDateTime { get; private set; }

		public string OriginalVeneu { get; private set; }

		public Gig Gig { get; private set; }

		[Required]
		public int GigId { get; private set; }

		protected Notification()
		{
		}

		private Notification(Gig gig,NotificationType type)
		{
			Gig = gig ?? throw new NullReferenceException("gig");
			NotificationType = type;
			DateTime = DateTime.Now;
		}

		public static Notification GigCreated(Gig gig)
		{
			return new Notification(gig,NotificationType.Created);
		}

		public static Notification GigUpdated(Gig newGig, DateTime dateTime, string veneu)
		{
			var notification = new Notification(newGig,NotificationType.Updated);
			notification.OriginalDateTime = dateTime;
			notification.OriginalVeneu = veneu;
			return notification;
		}

		public static Notification GigCancel(Gig gig)
		{
			return new Notification(gig,NotificationType.Canceled);
		}

	}
}