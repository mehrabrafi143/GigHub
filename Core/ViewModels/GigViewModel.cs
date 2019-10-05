using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
	public class GigViewModel
	{
		public IEnumerable<Gig> Gigs { get; set; }
		public bool IsAuthorize { get; set; }
		public string Heading { get; set; }
		public string Search { get; set; }
		public ILookup<int, Attendance> Attendances { get; set; }
	}
}