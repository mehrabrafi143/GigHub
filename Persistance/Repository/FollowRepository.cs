using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class FollowRepository : IFollowRepository
	{
		private readonly ApplicationDbContext _context;

		public FollowRepository(ApplicationDbContext context)
		{
			_context = context;
		}


		public bool IsExist(string userId, string followeeId)
		{
			return _context.Follows.Any(f => f.FolloweeId == followeeId && f.FollowerId == userId);
		}

		public void Add(Follow follow)
		{
			_context.Follows.Add(follow);
		}

		public Follow GetUserFolow(string userId, string followeeId)
		{
			return _context.Follows.Single(f => f.FolloweeId == followeeId && f.FollowerId == userId);
		}

		public void Remove(Follow follow)
		{
			_context.Follows.Remove(follow);
		}
	}
}