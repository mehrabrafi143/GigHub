using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels.Default
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}