using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels.Default
{
	public class ForgotViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}