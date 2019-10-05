using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class GigRepository : IGigRepository
	{
		private readonly ApplicationDbContext _context;

		public GigRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Gig> GetGigsUserAttending(string userId)
		{
			return _context.Attendances
				.Where(a => a.AttendeeId == userId)
				.Select(a => a.Gig)
				.Where(g => g.DateTime > DateTime.Now)
				.Include(g => g.Artist)
				.Include(g => g.Genre)
				.ToList();
		}

		public Gig GetGig(int id)
		{
			return _context.Gigs.SingleOrDefault(g => g.Id == id);
		}

		

		public Gig GetGigWithAttendees(int gigId)
		{
			return _context.Gigs
				.Include(g => g.Attendances.Select(a => a.Attendee))
				.SingleOrDefault(g => g.Id == gigId );
		}

		public IEnumerable<Gig> GetUserFutureGigsWithGenre(string userId)
		{
			return _context.Gigs.Where(g =>
					g.ArtistId == userId && g.DateTime > DateTime.Today && !g.IsCancel)
				    .Include(g => g.Genre).ToList();
		}

		public Gig GetGigWithAttendeesAndFollowers(int id)
		{
			return _context.Gigs
				.Include(g => g.Artist.Followers.Select(f => f.Follower))
				.Include(g => g.Attendances.Select(a => a.Attendee))
				.Single(g => g.Id == id);
		}

		public IEnumerable<Gig> GetAllFutureGigs()
		{
			return _context.Gigs
				.Include(g => g.Artist)
				.Include(g => g.Genre)
				.Where(g => !g.IsCancel && g.DateTime > DateTime.Today);
		}

		public IEnumerable<Gig> SearchGigByArtiestGenreVenue(string query, IEnumerable<Gig> gigs)
		{
			return gigs.Where(g =>
				g.Artist.Name.ToLower().Contains(query.ToLower()) ||
				g.Venue.ToLower().Contains(query.ToLower()) || g.Genre.Name.ToLower().Contains(query.ToLower()));
		}

		public void Add(Gig gig)
		{
			_context.Gigs.Add(gig);
		}
	}
}