using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.Repository;
using GigHub.Persistance.Repository;

namespace GigHub.Persistance
{
	public class UnitOfWork : IUnitOfWork
	{
	    private readonly ApplicationDbContext _context;
	    public IGigRepository Gigs { get; private set; }
		public IAttendanceRepository Attendances { get; private set; }
		public IGenreRepository Genres { get; private set; }
		public IUserRepository Users { get; private set; }
		public IFollowRepository Follows { get; private set; }
		public INotificationRepository Notifications { get; }
		public IUserNotificationRepository UserNotification { get; }

		public UnitOfWork(ApplicationDbContext context)
	    {
		    _context = context;
			Gigs = new GigRepository(context);
			Attendances = new AttendanceRepository(context);
			Genres = new GenreRepository(context);
			Users = new UserRepository(context);
			Follows = new FollowRepository(context);
			Notifications = new NotificationRepository(context);
			UserNotification = new UserNotificationRepository(context);
	    }

	    public void Complete()
	    {
		    _context.SaveChanges();
	    }

    }
}
