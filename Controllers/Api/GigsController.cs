using System.Web.Http;
using GigHub.Core;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
	[Authorize]
	public class GigsController : ApiController
	{
		private readonly IUnitOfWork _unitOfWork;

		public GigsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpDelete]
		public IHttpActionResult Cancel(int id)
		{
			var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

			if (gig == null || gig.IsCancel)
				return NotFound();


			if (gig.ArtistId != User.Identity.GetUserId())
				return Unauthorized();

			gig.Cancel();

			_unitOfWork.Complete();

			return Ok();
		}

	}
}
