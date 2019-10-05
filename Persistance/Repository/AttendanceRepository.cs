using System;
using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class AttendanceRepository : IAttendanceRepository
	{
		private readonly  ApplicationDbContext _context;

		public AttendanceRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Attendance> GetUserFutureAttendances(string userId)
		{
			return _context.Attendances.Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now).ToList();
		}

		public void Add(Attendance attendance)
		{
			_context.Attendances.Add(attendance);
		}

		public Attendance GetUserAttendance(int gigId, string user)
		{
			return _context.Attendances.SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == user);
		}

		public void Remove(Attendance attendence)
		{
			_context.Attendances.Remove(attendence);
		}
	}
}