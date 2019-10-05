using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IGigRepository
	{
		IEnumerable<Gig> GetGigsUserAttending(string userId);
		Gig GetGig(int id);
		Gig GetGigWithAttendees(int gigId);
		IEnumerable<Gig> GetUserFutureGigsWithGenre(string userId);
		Gig GetGigWithAttendeesAndFollowers(int id);
		void Add(Gig gig);
	}
}