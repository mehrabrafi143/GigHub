using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class UserNotificationRepository : IUserNotificationRepository
	{
		private readonly ApplicationDbContext _context;

		public UserNotificationRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<UserNotification> GetUserNotifications(string userId)
		{
			return _context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead).ToList();
		}
	}
}