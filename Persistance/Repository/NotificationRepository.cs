using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly ApplicationDbContext _context;

		public NotificationRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Notification> GetUserNotifications(string user)
		{
			
			 return _context.UserNotifications
				.Where(un => un.UserId == user && !un.IsRead)
				.Select(u => u.Notification)
				.Include(n => n.Gig.Artist)
				.ToList();
		}

		public IEnumerable<Notification> GetUserReadNotifications(string user)
		{
			var date = DateTime.Now.AddDays(-1);

			return _context.UserNotifications
				.Where(un => un.UserId == user && un.IsRead)
				.Select(u => u.Notification)
				.Where(n => n.DateTime > date)
				.Take(2)
				.Include(n => n.Gig.Artist)
				.ToList();
		}
	}
}