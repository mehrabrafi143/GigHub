using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using GigHub.Persistance;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
	    private readonly IUnitOfWork _unitOfWork;

	    public GigsController(IUnitOfWork unitOfWork)
	   {
		   _unitOfWork = unitOfWork;
	   }



	   [Authorize]
        public ActionResult Create()
        {
	        var viewModel = new GigFormView
	        {
				Genres = _unitOfWork.Genres.GetGenres()
	        };
            return View("GigForm",viewModel);
        }


        [Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Create(GigFormView model)
        {
	        if (!ModelState.IsValid)
	        {
		        model.Genres = _unitOfWork.Genres.GetGenres();
		        return View("GigForm",model);
	        }

	        var id = User.Identity.GetUserId();

	        var gig = new Gig
			{
				Artist = _unitOfWork.Users.GetArtistWithFollowers(id),
				DateTime = model.GetDateTime(),
				GenreId = model.GenreId,
				Venue = model.Venue
			};


		     gig.Created();

		     _unitOfWork.Gigs.Add(gig);
			 _unitOfWork.Complete();

	        return RedirectToAction("Mine", "Gigs");
        }

        

        [Authorize]
        public ActionResult Edit(int id)
        {
	        var gig = _unitOfWork.Gigs.GetGig(id);

			if(gig == null)
				return new HttpNotFoundResult("not found");

			if(gig.ArtistId != User.Identity.GetUserId())
				return new HttpUnauthorizedResult("you can't change it");

	        var viewModel = new GigFormView
	        {	
		        Genres = _unitOfWork.Genres.GetGenres(),
		        Date = gig.DateTime.ToString("dd-MM-yyyy"),
		        Time = gig.DateTime.ToString("HH:mm"),
		        Venue = gig.Venue,
		        GenreId = gig.GenreId,
				Id = gig.Id
	        };

	        return View("GigForm",viewModel);
        }


        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(GigFormView model)
        {

	        if (!ModelState.IsValid)
	        {
		        model.Genres = _unitOfWork.Genres.GetGenres();
		        View("GigForm",model);
	        }

	        var gig = _unitOfWork.Gigs.GetGigWithAttendees(model.Id);

			if (gig == null)
				return HttpNotFound();

			if (gig.ArtistId != User.Identity.GetUserId())
				return new HttpUnauthorizedResult();


	        gig.Modify(model.GetDateTime(), model.Venue, model.GenreId);


			_unitOfWork.Complete();

	        return RedirectToAction("Mine");
        }



		[Authorize]
        public ActionResult Attending()
        {
	        var userId = User.Identity.GetUserId();

	        var viewModel = new GigViewModel
			{
				Gigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
				IsAuthorize = User.Identity.IsAuthenticated,
				Heading = "I'm going",
				Attendances = _unitOfWork.Attendances.GetUserFutureAttendances(userId).ToLookup(a => a.GigId)
			};

			return View("Gigs",viewModel);
        }

        

        

        [Authorize]
        public ActionResult Mine()
        {
	        var gigs = _unitOfWork.Gigs.GetUserFutureGigsWithGenre(User.Identity.GetUserId());

	        return View(gigs);
        }

		[HttpPost]
        public ActionResult Search(string search)
        {

	        return RedirectToAction("Index","Home",new {query = search});

        }

        public ActionResult Details(int id)
        {
	        var userId = User.Identity.GetUserId();

	        var gig = _unitOfWork.Gigs.GetGigWithAttendeesAndFollowers(id);

	        var model = new GigDetailsViewModel
	        {
				Gig = gig,
				IsAuthourize = User.Identity.IsAuthenticated
			};

	        if (!model.IsAuthourize) return View("Details", model);


	        model.IsFollowing = gig.Artist.IsFollowing(userId);
	        model.IsGoing = gig.IsGoing(userId);


	        return View("Details",model);
        }
    }
}