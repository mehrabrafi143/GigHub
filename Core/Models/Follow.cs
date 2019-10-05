using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Core.Models
{
	public class 
		Follow
	{
		public ApplicationUser Followee { get; set; }
		public ApplicationUser Follower { get; set; }
        
		[Column(Order = 1)]
		[Key]
		public string FolloweeId { get; set; }

		[Column(Order = 2)]
		[Key]
		public string FollowerId { get; set; }
	}
}