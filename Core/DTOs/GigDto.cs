using System;

namespace GigHub.Core.DTOs
{
	public class GigDto	
	{
		public int Id { get; set; }
		public UserDto Artist { get; set; }
		public string Venue { get; set; }
		public GenreDto Genre { get; set; }
		public DateTime DateTime { get; set; }
		public bool IsCancel { get; set; }
	}
}