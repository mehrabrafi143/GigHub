using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IUserNotificationRepository
	{
		IEnumerable<UserNotification> GetUserNotifications(string userId);
	}
}