using System.Web.Mvc;
using System.Linq;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public ActionResult Index(string query = null)
		{
			var gigs = _unitOfWork.Gigs.GetAllFutureGigs();
				

			if (!string.IsNullOrWhiteSpace(query))
			{
		       gigs =  _unitOfWork.Gigs.SearchGigByArtiestGenreVenue(query, gigs);
			}


			var model = new GigViewModel
			{
				Gigs = gigs,
				Heading = "Gigs Feed",
				IsAuthorize = User.Identity.IsAuthenticated,
				Search = query,
				Attendances = _unitOfWork
					.Attendances
					.GetUserFutureAttendances(User.Identity.GetUserId())
					.ToLookup(a => a.GigId)
			};
			return View("Gigs",model);
		}
	}
}