using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Core.Models
{
	public class UserNotification
	{

		[Key]
		[Column(Order = 1)]
		[StringLength(128)]
		public string UserId { get; private set; }

		[Key]
		[Column(Order = 2)]
		public int NotificationId { get; private set; }

		public ApplicationUser User { get; private set; }
		public Notification Notification { get; private set; }

		public bool IsRead { get; set; }

		protected UserNotification()
		{
			
		}

		public UserNotification(ApplicationUser user, Notification notification)
		{
			User = user ?? throw new NullReferenceException("user");
			Notification = notification ?? throw new NullReferenceException("notification");
		}

		public void Read()
		{
			IsRead = true;
		}
	}
}