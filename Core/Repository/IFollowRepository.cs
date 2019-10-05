using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IFollowRepository
	{
		bool IsExist(string userId, string followeeId);
		void Add(Follow follow);
		Follow GetUserFolow(string userId, string followeeId);
		void Remove(Follow follow);
	}
}