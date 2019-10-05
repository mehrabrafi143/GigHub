using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public ApplicationUser GetArtistWithFollowers(string id)
		{
			return _context.Users.Include(u => Enumerable.Select<Follow, ApplicationUser>(u.Followers, f => f.Follower)).Single(u => u.Id == id);
		}

	}
}