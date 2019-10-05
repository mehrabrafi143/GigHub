using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Core.Models;
using GigHub.Persistance;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class FollowsController : Controller
    {
	    private readonly ApplicationDbContext _context;

	    public FollowsController()
	    {
		    _context = new ApplicationDbContext();
	    }

        // GET: Follows
        public ActionResult Index()
        {
	        var user = User.Identity.GetUserId();
	        var follwing = _context.Follows.Where(f => f.FollowerId == user).Select(f => f.Followee).ToList();

	        return View(follwing);

        }
    }
}