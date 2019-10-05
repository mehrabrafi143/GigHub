using GigHub.Core.Repository;

namespace GigHub.Core
{
	public interface IUnitOfWork
	{
		IGigRepository Gigs { get; }
		IAttendanceRepository Attendances { get; }
		IGenreRepository Genres { get; }
		IUserRepository Users { get; }
		void Complete();
	}
}