using System;
using GigHub.Core.Models;

namespace GigHub.Core.DTOs
{
	public class NotificationDto
	{
		public DateTime DateTime { get; set; }
		public NotificationType NotificationType { get; set; }
		public DateTime? OriginalDateTime { get; set; }
		public string OriginalVeneu { get; set; }
		public GigDto Gig { get; set; }
	}
}