using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repository;

namespace GigHub.Persistance.Repository
{
	public class GenreRepository : IGenreRepository
	{
		private readonly ApplicationDbContext _context;

		public GenreRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Genre> GetGenres()
		{
			return _context.Genres.ToList();
		}
	}
}