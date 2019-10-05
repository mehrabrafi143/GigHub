using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repository
{
	public interface IGenreRepository
	{
		IEnumerable<Genre> GetGenres();
	}
}