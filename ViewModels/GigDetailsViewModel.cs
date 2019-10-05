using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
	public class GigDetailsViewModel
	{
		public Gig Gig { get; set; }
		public bool IsGoing { get; set; }
		public bool IsFollowing { get; set; }
		public string FlowText => IsFollowing ? "Following btn-primary" : "Follow btn-link";
		public bool IsAuthourize { get; set; }
	}
}