using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.Persistance.Repository;

namespace GigHub.Core.Repository
{
	public interface INotificationRepository
	{
		IEnumerable<Notification> GetUserNotifications(string user);
		IEnumerable<Notification> GetUserReadNotifications(string user);
	}
}