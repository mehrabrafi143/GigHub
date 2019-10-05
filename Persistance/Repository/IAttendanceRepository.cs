using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IAttendanceRepository
	{
		IEnumerable<Attendance> GetUserFutureAttendances(string userId);
	}
}