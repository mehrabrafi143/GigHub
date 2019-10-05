using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IUserRepository
	{
		ApplicationUser GetArtistWithFollowers(string id);
	}
}